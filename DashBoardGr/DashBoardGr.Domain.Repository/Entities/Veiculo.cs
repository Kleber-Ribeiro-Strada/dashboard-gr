using System.Data;

namespace DashBoardGr.Domain.Repository.Entities
{
    public class Veiculo
    {
        public Guid Id { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public string Placa { get; set; } = string.Empty;
        public string Chassi { get; set; } = string.Empty;
        public string Renavam { get; set; } = string.Empty;
        public string Rntrc { get; set; } = string.Empty;
        public DateTime DataLicenciamento { get; set; }
        public string Cor { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; } 
        public string Estado { get; set; } = string.Empty;
        public string CodigoCidade { get; set; } = string.Empty;
        public string ImagemCrlv { get; set; } = string.Empty;

        public Guid ProprietarioId { get; set; }
        public virtual Proprietario Proprietario { get; set; } = null!;

    }
}