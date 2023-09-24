using DashBoardGr.Domain.Shared.Commands.Response;
using MediatR;
using System.Text.Json.Serialization;

namespace DashBoardGr.Domain.Application.Commands.SolicitarAnalise
{
    public class SolicitarAnaliseCommand : IRequest<CommandResponse>
    {

        public DateTime DataRequisicao { get; set; } 

        public Guid MotoristaId { get; set; }
        public ProprietarioCommand Proprietario { get; set; } = new();
        public List<VeiculoCommand> Veiculos { get; set; } = new();


        public class ProprietarioCommand
        {
            public string CpfCnpj { get; set; } = string.Empty;
            public string Nome { get; set; } = string.Empty;
            public string Cep { get; set; } = string.Empty;
            public string CodigoCidade { get; set; } = string.Empty;
            public string NomeCidade { get; set; } = string.Empty;
            public string Rua { get; set; } = string.Empty;
            public string Numero { get; set; } = string.Empty;
            public string? Complemento { get; set; }
            public string Bairro { get; set; } = string.Empty;
            public string Estado { get; set; } = string.Empty;
            public string Telefone { get; set; } = string.Empty;
        }

        public class VeiculoCommand
        {
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
        }

    }
}