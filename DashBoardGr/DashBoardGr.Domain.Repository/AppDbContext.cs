using DashBoardGr.Domain.Repository.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Escaneia o assembly em busca de classes que implementam IEntityTypeConfiguration<>
            var types = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type =>
                    type.GetInterfaces()
                        .Any(interfaceType =>
                            interfaceType.IsGenericType &&
                            interfaceType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)))
                .ToList();

            // Cria instâncias das classes de configuração encontradas e aplica-as ao modelBuilder
            foreach (var type in types)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }

        }
    }
}
