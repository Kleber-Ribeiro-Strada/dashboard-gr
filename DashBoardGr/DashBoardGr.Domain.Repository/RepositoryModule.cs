using DashBoardGr.Domain.Repository.Repositories.Implementation;
using DashBoardGr.Domain.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Repository
{
    public static class RepositoryModule
    {
        public static IServiceCollection AddRepositoryContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServer"), x => x.MigrationsAssembly("Api")));

            services.AddTransient<IMotoristaRepository, MotoristaRepository>();
            return services;
        }
    }
}
