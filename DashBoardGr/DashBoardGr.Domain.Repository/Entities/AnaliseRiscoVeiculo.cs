﻿

namespace DashBoardGr.Domain.Repository.Entities
{
    public class AnaliseRiscoVeiculo
    {
        public AnaliseRiscoVeiculo(
            Guid analiseRiscoId,
            Guid veiculoId)
        {
            Id = Guid.NewGuid();
            AnaliseRiscoId = analiseRiscoId; 
            VeiculoId = veiculoId;
        }
        public Guid Id { get; set; }

        public Guid AnaliseRiscoId { get; set; }
        public virtual AnaliseRisco AnaliseRisco { get; private set; } = null!;

        public Guid VeiculoId { get; set; }
        public virtual Veiculo Veiculo { get; private set; } = null!;


    }
}
