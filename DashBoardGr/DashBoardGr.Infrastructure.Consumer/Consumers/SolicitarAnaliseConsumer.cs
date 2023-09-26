using Bogus;
using DashBoardGr.Domain.Application.Commands.AvaliarAnalise;
using DashBoardGr.Domain.Application.Enums;
using DashBoardGr.Domain.Shared;
using MediatR;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace DashBoardGr.Infrastructure.Consumer.Recivers
{
    public class SolicitarAnaliseConsumer : BackgroundService
    {
        private readonly ILogger<SolicitarAnaliseConsumer> _logger;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;

        public SolicitarAnaliseConsumer(
            ILogger<SolicitarAnaliseConsumer> logger,
            IRabbitMQConfiguration rabbitMQConfig,
            IServiceProvider serviceProvider)
        {
            _connection = rabbitMQConfig.GetConnectionFactory().CreateConnection();
            _channel = _connection.CreateModel();
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (sender, eventArgs) =>
            {
                var contentArray = eventArgs.Body.ToArray();
                var contentString = Encoding.UTF8.GetString(contentArray);

                var @event = JsonSerializer.Deserialize<Analise>(contentString);

                bool aprovado = new RandomEx().NextBoolean();
                if (aprovado)
                {
                    Aprovar(@event.Id);
                }
                else
                {
                    Reprovar(@event.Id);
                }

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };
            _channel.BasicConsume("analise-solicitada", false, consumer);
            return Task.CompletedTask;
        }

        private async void Avaliar(AvaliarAnaliseNotification command)
        {
            using var scope = _serviceProvider.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();


            await mediator.Publish(command);
        }

        private class Analise
        {
            public Guid Id { get; set; }
        }


        private void Reprovar(Guid Id)
        {
            var fakerCmd = new Faker<AvaliarAnaliseNotification>("pt_BR")
                .RuleFor(a => a.Motivo, f => f.Random.Enum<EMotivo>())
                .RuleFor(a => a.Observacao, f => f.Random.Words());

            var cmd = fakerCmd.Generate();
            cmd.Status = EStatus.Reprovado;
            cmd.Id = Id;
            Avaliar(cmd);
        }

        private void Aprovar(Guid Id)
        {
            Avaliar(new AvaliarAnaliseNotification
            {
                Id = Id,
                Motivo = null,
                Status = EStatus.Aprovado,
            });
        }
    }
}
