﻿
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
            MotoristaId = motoristaId;
            CnhId = cnhId;
            DataSolicitacaoAnalise = DateTime.Now;
            DataAvaliacao = null;

            Status = status;
            
            
            Observacao = null;
        }

        public Guid Id { get; private set; }

        public DateTime DataSolicitacaoAnalise { get; private set; }

        public DateTime? DataAvaliacao { get; private set; }

        public string Status { get; private set; } 

        public string? Observacao { get; set; }

        public string? Motivo { get; set; }

        public Guid MotoristaId { get; private set; }
        public virtual Motorista Motorista { get; private set; } = null!;

        public Guid CnhId { get; set; }
        public virtual Cnh Cnh { get; set; } = null!;

        public virtual ICollection<AnaliseRiscoVeiculo> AnaliseRiscoVeiculos { get; set; } = null!;


        public void Avaliar(string status, string motivo, string observacao)
        {
            Status = status;
            Observacao = observacao;
            Motivo = motivo;
            DataAvaliacao = DateTime.Now;
        }
    }
}
