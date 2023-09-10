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
        //private IConnection _connection;
        //private IModel _channel;
        private const string _exchange = "";
        public RabbitMqService()
        {
            
        }

        public Task Publish<T>(T data, string routingKey)
        {

            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            };

            using var _connection = connectionFactory.CreateConnection();
            using var channel = _connection.CreateModel();

            var _channel = _connection.CreateModel();

            _channel.QueueDeclare(queue: "fila-fila",
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);


            var type = data.GetType();
            var payload = JsonSerializer.Serialize(data);
            var byteArray = Encoding.UTF8.GetBytes(payload);

            Console.WriteLine($"{type.Name} Published");
            _channel.BasicPublish(_exchange, "fila-fila", null, byteArray);

            return Task.CompletedTask;
        }
    }
}
