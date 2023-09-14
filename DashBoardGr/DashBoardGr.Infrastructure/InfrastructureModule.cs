using DashBoardGr.Infrastructure.BuscarCep.ExternalServices;
using DashBoardGr.Infrastructure.ExternalServices;
using DashBoardGr.Infrastructure.Messaging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddMessageBus(this IServiceCollection services)
        {
            services.AddScoped<IRabbitMQConfiguration, RabbitMQConfiguration>();
            services.AddScoped<IMessageBusService, RabbitMqService>();
            services.AddHttpClient<BuscarEnderecoService>(c => c.BaseAddress = new Uri("https://viacep.com.br/ws/"));

            return services;
        }
    }
}
