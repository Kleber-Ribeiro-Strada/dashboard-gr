namespace DashBoardGr.Domain.Repository.Entities
{
    public class Motorista
    {
        public Motorista()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }

        public string Nome { get; private set; } = string.Empty;
        public string Genero { get; private set; } = string.Empty;
        public DateTime DataNascimento { get; private set; }
        public string Cpf { get; private set; } = string.Empty;
        public string Rg { get; private set; } = string.Empty;
        public string? EstadoEmissao { get; private set; }
        public DateTime DataEmissao { get; private set; }
        public string NomeMae { get; private set; } = string.Empty;
        public string? NomePai { get; private set; }
        public string Telefone { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string? NomeReferencia { get; private set; }
        public string? TelefoneReferencia { get; private set; }
        public string Cep { get; private set; } = string.Empty;
        public string CodigoCidade { get; private set; } = string.Empty;
        public string? NomeCidade { get; private set; }
        public string? Rua { get; private set; }
        public string Numero { get; private set; } = string.Empty;
        public string? Complemento { get; private set; }
        public string? Bairro { get; private set; }
        public string? Estado { get; private set; }



        public virtual ICollection<Cnh> Cnhs { get; private set; } = null!;
    }
}
