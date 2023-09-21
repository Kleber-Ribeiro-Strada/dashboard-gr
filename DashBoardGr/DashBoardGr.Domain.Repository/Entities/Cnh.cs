namespace DashBoardGr.Domain.Repository.Entities
{
    public class Cnh
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Numero { get; private set; } = string.Empty;
        public string? EstadoEmissao { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public string Categoria { get; private set; } = string.Empty;
        public string? CodigoCidade { get; private set; }
        public string? CodigoSeguranca { get; private set; }
        public DateTime? DataPrimeiraHabilitacao { get; private set; }
        public string? Imagem { get; private set; }

        public Guid MotoristaId { get; set; }
        public virtual Motorista Motorista { get; set; } = null!;

        public virtual ICollection<AnaliseRisco> Analises { get; set; }
    }
}
