using DashBoardGr.Domain.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace DashBoardGr.Domain.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cnh> Cnh { get; set; }
        public DbSet<Motorista> Motorista { get; set; }
        public DbSet<Proprietario> Proprietario { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<AnaliseRisco> AnaliseRisco { get; set; }
        public DbSet<AnaliseRiscoVeiculo> AnaliseRiscoVeiculo { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
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
