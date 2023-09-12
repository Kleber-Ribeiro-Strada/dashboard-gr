namespace DashBoardGr.Domain.Repository.Entities
{
    public class Veiculo
    {
        public Guid Id { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public string? Placa { get; set; }
        public string? Chassi { get; set; }
        public string? Renavam { get; set; }
        public string? Rntrc { get; set; }
        public DateTime DataLicenciamento { get; set; }
        public string? Cor { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }
        public string? Estado { get; set; }
        public string? CodigoCidade { get; set; }
        public string? ImagemCrlv { get; set; }

        public Guid ProprietarioId { get; set; }
        public virtual Proprietario Proprietario { get; set; } = new();

    }
}