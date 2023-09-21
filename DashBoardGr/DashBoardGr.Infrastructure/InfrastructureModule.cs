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
        public static IServiceCollection AddExternalServices(this IServiceCollection services)
        {
            services.AddHttpClient<BuscarEnderecoService>(c => c.BaseAddress = new Uri("https://viacep.com.br/ws/"));
            return services;
        }
        public static IServiceCollection AddMessageBus(this IServiceCollection services)
        {
            services.AddSingleton<IRabbitMQConfiguration, RabbitMQConfiguration>();
            services.AddSingleton<IMessageBusService, RabbitMqService>();

            return services;
        }
    }
}
