namespace DashBoardGr.Domain.Application.Queries.AnaliseQueries.BuscarAnalise
{
    public class BuscarAnaliseViewModel
    {
        public Guid Id { get; set; }

        public DateTime DataSolicitacaoAnalise { get; set; }

        public DateTime? DataAvaliacao { get; set; }

        public string Status { get; set; } = string.Empty;

        public string? Observacao { get; set; }

        public string? Motivo { get; set; }

        public string NomeMotorista { get; set; } = string.Empty;

        public string Cpf { get; set; } = string.Empty;
    }
}
