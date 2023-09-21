using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Repository.Entities
{
    public class AnaliseRisco
    {
        public AnaliseRisco(
            string status,
            Guid motoristaId, 
            Guid cnhId)
        {
            Id = Guid.NewGuid();
            DataSolicitacaoAnalise = DateTime.Now;
            DataAvaliacao = null;
            Status = status;
            Observacao = null;
        }

        public Guid Id { get; private set; }

        public DateTime DataSolicitacaoAnalise { get; private set; }

        public DateTime? DataAvaliacao { get; private set; }

        public string Status { get; private set; } = string.Empty;

        public string? Observacao { get; set; } 

        public Guid MotoristaId { get; private set; }
        public virtual Motorista Motorista { get; private set; } = null!;

        public Guid CnhId { get; set; }
        public virtual Cnh Cnh { get; set; } = null!;

        public virtual ICollection<AnaliseRiscoVeiculo> AnaliseRiscoVeiculos { get; set; } = null!;
    }
}
