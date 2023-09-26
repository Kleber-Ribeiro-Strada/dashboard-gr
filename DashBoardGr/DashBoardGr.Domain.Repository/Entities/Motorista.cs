namespace DashBoardGr.Domain.Repository.Entities
{
    public class Motorista
    {
        public Motorista()
        {
            Id = Guid.NewGuid();
        }
        public Motorista(
            string nome,
            string genero,
            DateTime dataNascimento,
            string cpf,
            string rg, 
            string? estadoEmissao,
            DateTime dataEmissao,
            string nomeMae,
            string? nomePai,
            string telefone,
            string email,
            string? nomeReferencia,
            string? telefoneReferencia,
            string cep,
            string codigoCidade,
            string nomeCidade,
            string rua,
            string numero,
            string? complemento,
            string bairro,
            string estado)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Genero = genero;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            Rg = rg;
            EstadoEmissao = estadoEmissao;
            DataEmissao = dataEmissao;
            NomeMae = nomeMae;
            NomePai = nomePai;
            Telefone = telefone;
            Email = email;
            NomeReferencia = nomeReferencia;
            TelefoneReferencia = telefoneReferencia;
            Cep = cep;
            CodigoCidade = codigoCidade;
            NomeCidade = nomeCidade;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Estado = estado;
        }
        public Guid Id { get; private set; }

        public string Nome { get; private set; } 
        public string Genero { get; private set; } 
        public DateTime DataNascimento { get; private set; }
        public string Cpf { get; private set; } 
        public string Rg { get; private set; } 
        public string? EstadoEmissao { get; private set; }
        public DateTime DataEmissao { get; private set; }
        public string NomeMae { get; private set; } 
        public string? NomePai { get; private set; }
        public string Telefone { get; private set; } 
        public string Email { get; private set; } 
        public string? NomeReferencia { get; private set; }
        public string? TelefoneReferencia { get; private set; }
        public string Cep { get; private set; } 
        public string CodigoCidade { get; private set; } 
        public string? NomeCidade { get; private set; }
        public string? Rua { get; private set; }
        public string Numero { get; private set; } 
        public string? Complemento { get; private set; }
        public string? Bairro { get; private set; }
        public string? Estado { get; private set; }



        public virtual ICollection<Cnh> Cnhs { get; private set; } = null!;
        public virtual ICollection<AnaliseRisco> Analises { get; private set; } = null!;
    }
}
