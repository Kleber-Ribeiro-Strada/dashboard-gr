using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Queries.BuscarMotoristas
{
    public class BuscarMotoristasViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public BuscarMotoristasAnaliseViewModel Analise { get; set; } = new();

        public class BuscarMotoristasAnaliseViewModel
        {
            public Guid Id { get; set; }
            public DateTime DataSolicitacaoAnalise { get; set; }

            public DateTime? DataAvaliacao { get; set; }

            public string Status { get; set; } = string.Empty;

            public string? Observacao { get; set; }

        }
    }

    
}
