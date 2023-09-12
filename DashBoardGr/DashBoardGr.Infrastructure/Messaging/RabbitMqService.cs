using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace DashBoardGr.Infrastructure.Messaging
{
    public class RabbitMqService : IMessageBusService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string _exchange = "analise-exchange";
        public RabbitMqService(IRabbitMQConfiguration rabbitMQConfig)
        {
            _connection = rabbitMQConfig.GetConnectionFactory().CreateConnection();
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
