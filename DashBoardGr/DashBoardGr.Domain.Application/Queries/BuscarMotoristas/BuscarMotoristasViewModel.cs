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
        public string Rua { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;

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
