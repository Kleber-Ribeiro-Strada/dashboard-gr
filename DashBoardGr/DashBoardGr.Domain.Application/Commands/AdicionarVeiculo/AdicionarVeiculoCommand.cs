using DashBoardGr.Domain.Shared.Commands.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static DashBoardGr.Domain.Application.Commands.SolicitarAnalise.SolicitarAnaliseCommand;

namespace DashBoardGr.Domain.Application.Commands.AdicionarVeiculo
{
    public class AdicionarVeiculoCommand: CommandRequest
    {
        [JsonIgnore]
        public Guid MotoristaId { get; set; }

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
        public AdicionarProprietarioVeiculo Proprietario { get; set; } = new();
        public string ImagemCrlv { get; set; } = string.Empty;
    }

    public class AdicionarProprietarioVeiculo
    {
        public string CpfCnpj { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;

        [JsonIgnore]
        public string? CodigoCidade { get; set; }
        public string? NomeCidade { get; set; }

        [JsonIgnore]
        public string? Rua { get; set; }
        public string Numero { get; set; } = string.Empty;
        public string? Complemento { get; set; }

        [JsonIgnore]
        public string? Bairro { get; set; }

        [JsonIgnore]
        public string? Estado { get; set; }
        public string Telefone { get; set; } = string.Empty;
    }
}
