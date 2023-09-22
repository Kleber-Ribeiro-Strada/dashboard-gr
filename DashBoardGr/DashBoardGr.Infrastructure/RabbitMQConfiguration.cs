using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace DashBoardGr.Infrastructure
{
    public interface IRabbitMQConfiguration
    {
        ConnectionFactory GetConnectionFactory();
    }

    public class RabbitMQConfiguration : IRabbitMQConfiguration
    {
        private readonly ConnectionFactory? _factory;
        private readonly IConfiguration _configuration;
        public RabbitMQConfiguration(IConfiguration configuraion)
        {
            _configuration = configuraion;

            var rabbitParameter = _configuration.GetSection("RabbitMq").Get<RabbitParameter>();
            if (rabbitParameter == null)
            {
                return;
            }
            _factory = new ConnectionFactory
            {
                HostName = rabbitParameter.HostName, 
                Port = rabbitParameter.Port
            };

            // Configurar e criar elementos necessários (filas, exchanges, topics) aqui
            using var connection = _factory.CreateConnection();
            using var channel = connection.CreateModel();

            if (rabbitParameter.Exchanges == null)
                return;

            var exchangeAnaliseRisco = rabbitParameter.Exchanges.First(x => x.ExchangeName == "analise-exchange");

            channel.ExchangeDeclare(exchangeAnaliseRisco.ExchangeName, "x-delayed-message", true, false, new Dictionary<string, object>
            {
                { "x-delayed-type", "direct" } // Substitua "topic" pelo tipo de troca que você deseja usar como base
            });

            foreach (var queue in exchangeAnaliseRisco.Queues)
            {
                var queueName = queue.Split(',')[0].Trim();
                var routingKeyName = queue.Split(',')[1].Trim();

                channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
                channel.QueueBind(queue: queueName, exchange: exchangeAnaliseRisco.ExchangeName, routingKey: routingKeyName);
            }




            foreach (var exchange in rabbitParameter.Exchanges.Where(x=>x.ExchangeName!= "analise-exchange"))
            {
                channel.ExchangeDeclare(exchange: exchange.ExchangeName, type: ExchangeType.Topic);

                foreach (var queue in exchange.Queues)
                {
                    var queueName = queue.Split(',')[0].Trim();
                    var routingKeyName = queue.Split(',')[1].Trim();

                    channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
                    channel.QueueBind(queue: queueName, exchange: exchange.ExchangeName, routingKey: routingKeyName);
                }
            }
        }

        public ConnectionFactory GetConnectionFactory() => _factory;
    }
}
