using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DashBoardGr.Infrastructure.Messaging
{
    public class RabbitMqService : IMessageBusService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string _exchange = "solicitar-analise-exgange";
        private IConfiguration _configuration;
        public RabbitMqService(IConfiguration configuration)
        {
            _configuration = configuration;
            
            var factory = new ConnectionFactory
            {
                HostName = "localhost", // Endereço do servidor RabbitMQ,
                Port = int.Parse(_configuration.GetSection("RabbitMq:Port").Value)
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public Task Publish<T>(T data, string? routingKey = null)
        {
            var type = data?.GetType();
            var payload = JsonSerializer.Serialize(data);
            var byteArray = Encoding.UTF8.GetBytes(payload);

            if (string.IsNullOrEmpty(routingKey))
            {
                switch (type?.Name)
                {
                    case "SolicitarAnaliseCommand":
                        routingKey = "solicitar-analise.*";
                        break;
                }
            }

            _channel.BasicPublish(_exchange, routingKey, null, byteArray);
            Console.WriteLine($"{type?.Name} Published");
            return Task.CompletedTask;
        }
    }
}
