using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DashBoardGr.Carga.Models
{
    internal class SolicitarAnaliseCommand
    {
        [JsonIgnore]
        public DateTime DataRequisicao { get; set; } = DateTime.Now;

        public Guid MotoristaId { get; set; }
        public ProprietarioCommand Proprietario { get; set; } = new();
        public List<VeiculoCommand> Veiculos { get; set; } = new();


        public class ProprietarioCommand
        {
            public string CpfCnpj { get; set; } = string.Empty;
            public string Nome { get; set; } = string.Empty;
            public string Cep { get; set; } = string.Empty;
            public string? CodigoCidade { get; set; }
            public string? NomeCidade { get; set; }
            public string? Rua { get; set; }
            public string Numero { get; set; } = string.Empty;
            public string? Complemento { get; set; }
            public string? Bairro { get; set; }
            public string? Estado { get; set; }
            public string Telefone { get; set; } = string.Empty;
        }

        public class VeiculoCommand
        {
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
        }
    }
}
