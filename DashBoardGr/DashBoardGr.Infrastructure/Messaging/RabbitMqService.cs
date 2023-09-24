using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;

namespace DashBoardGr.Infrastructure.Messaging
{
    public class RabbitMqService : IMessageBusService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string _exchange = "analise-exchange";
        private readonly IBasicProperties _basicProperties;
        public RabbitMqService(IRabbitMQConfiguration rabbitMQConfig)
        {
            _connection = rabbitMQConfig.GetConnectionFactory().CreateConnection();
            _channel = _connection.CreateModel();
            _basicProperties = _channel.CreateBasicProperties();
            _basicProperties.Headers = new Dictionary<string, object>
            {
                { "x-delay", 300000  } // Atraso de 5 segundos
            };
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
                        _channel.BasicPublish(_exchange, "solicitar-analise.solicitar-analise-routing", _basicProperties, byteArray);
                        break;
                    default:
                        _channel.BasicPublish(_exchange, routingKey, null, byteArray);
                        break;

                }
            }

            Console.WriteLine($"{type?.Name} Published");
            return Task.CompletedTask;
        }
    }
}
