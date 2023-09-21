using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DashBoardGr.Infrastructure.Consumer.Recivers
{
    public class SolicitarAnaliseConsumer : BackgroundService
    {
        private readonly ILogger<SolicitarAnaliseConsumer> _logger;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        public SolicitarAnaliseConsumer(ILogger<SolicitarAnaliseConsumer> logger, IRabbitMQConfiguration rabbitMQConfig)
        {
            _connection = rabbitMQConfig.GetConnectionFactory().CreateConnection();
            _channel = _connection.CreateModel();
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (sender, eventArgs) =>
            {
                var contentArray = eventArgs.Body.ToArray();
                var contentString = Encoding.UTF8.GetString(contentArray);

                var @event = JsonSerializer.Deserialize<object>(contentString);

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };
            _channel.BasicConsume("analise-solicitada", false, consumer);
            return Task.CompletedTask;
        }
    }
}
