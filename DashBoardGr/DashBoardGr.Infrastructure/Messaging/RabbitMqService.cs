using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DashBoardGr.Infrastructure.Messaging
{
    public class RabbitMqService : IMessageBusService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string _exchange = "solicitar-analise-service";
        public RabbitMqService()
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost",
            };

            _connection = connectionFactory.CreateConnection("solicitar-analise-publisher");
            _channel = _connection.CreateModel();
        }

        public Task Publish(object data, string routingKey)
        {
            var type = data.GetType();
            var payload = JsonSerializer.Serialize(data); 
            var byteArray = Encoding.UTF8.GetBytes(payload);

            Console.WriteLine($"{type.Name} Published");
            _channel.BasicPublish(_exchange, routingKey, null, byteArray);

            return Task.CompletedTask;
        }
    }
}
