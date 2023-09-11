using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Infrastructure
{
    public class RabbitMQConfiguration
    {
        private readonly ConnectionFactory _factory;
        public RabbitMQConfiguration(string hostName, string userName, string password)
        {
            _factory = new ConnectionFactory
            {
                HostName = hostName,
                UserName = userName,
                Password = password
            };

            // Configurar e criar elementos necessários (filas, exchanges, topics) aqui
            using (var connection = _factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                // Criar uma fila
                channel.QueueDeclare(queue: "minha_fila", durable: false, exclusive: false, autoDelete: false, arguments: null);

                // Criar uma exchange
                channel.ExchangeDeclare(exchange: "minha_exchange", type: ExchangeType.Direct);

                // Vincular a fila à exchange
                channel.QueueBind(queue: "minha_fila", exchange: "minha_exchange", routingKey: "minha_routing_key");
            }
        }

        // Métodos para criar outras configurações RabbitMQ, se necessário
    }

}
