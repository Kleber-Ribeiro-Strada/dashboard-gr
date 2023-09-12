using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Infrastructure
{
    public class RabbitParameter
    {
        public string HostName { get; set; } = string.Empty;

        public int Port { get; set; }

        public List<ExchangeRabbitParameter> Exchanges { get; set; } = new();
    }

    public class ExchangeRabbitParameter
    {
        public string ExchangeName { get; set; } = string.Empty;

        public List<string> Queues { get; set; } = new();
    }
}
