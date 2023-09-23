using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Queries.BuscarAnalisesRelatorio
{
    public class BuscarAnalisesGraficoViewModel
    {
        public Guid Id { get; set; }

        public DateTime DataSolicitacaoAnalise { get; private set; }

        public DateTime? DataAvaliacao { get; private set; }

        public string Status { get; private set; } = string.Empty;

        public string? Observacao { get; set; }

        public string NomeMotorista { get; set; } = string.Empty;

        public string Cpf { get; set; } = string.Empty;

        public string Placa { get; set; } = string.Empty;


    }
}
