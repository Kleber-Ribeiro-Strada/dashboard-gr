namespace DashBoardGr.Domain.Repository.Entities
{
    public class Cnh
    {
        public Cnh()
        {
            Numero = string.Empty;
            Categoria = string.Empty; 
        }
        public Cnh(
            Guid motoristaId,
            string numero,
            string estadoEmissao,
            DateTime dataVencimento,
            string categoria, 
            string? codigoCidade,
            string? codigoSeguranca,
            DateTime? dataPrimeiraHabilitacao,
            string? imagem)
        {
            Id = Guid.NewGuid();
            Numero = numero;
            EstadoEmissao = estadoEmissao;
            DataVencimento = dataVencimento;
            Categoria = categoria;
            CodigoCidade = codigoCidade;
            CodigoSeguranca = codigoSeguranca;
            DataPrimeiraHabilitacao = dataPrimeiraHabilitacao;
            Imagem = imagem;
            MotoristaId = motoristaId;
            
        }
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Numero { get; private set; } 
        public string? EstadoEmissao { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public string Categoria { get; private set; }
        public string? CodigoCidade { get; private set; }
        public string? CodigoSeguranca { get; private set; }
        public DateTime? DataPrimeiraHabilitacao { get; private set; }
        public string? Imagem { get; private set; }

        public Guid MotoristaId { get; set; }
        public virtual Motorista Motorista { get; set; } = null!;

        public virtual ICollection<AnaliseRisco> Analises { get; set; } = null!;
    }
}
