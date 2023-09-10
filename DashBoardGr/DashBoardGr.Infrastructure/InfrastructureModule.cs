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
            services.AddScoped<IMessageBusService, RabbitMqService>();

            return services;
        }
    }
}
