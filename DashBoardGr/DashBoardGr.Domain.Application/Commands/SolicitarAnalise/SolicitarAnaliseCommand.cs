using MediatR;
using System.Text.Json.Serialization;

namespace DashBoardGr.Domain.Application.Commands.SolicitarAnalise
{
    public class SolicitarAnaliseCommand : IRequest<Unit>
    {

        public long? Id { get; set; }

        [JsonIgnore]
        public DateTime DataRequisicao { get; set; } = DateTime.Now;
        public MotoristaCommand Motorista { get; set; } = new();
        public List<VeiculoCommand> Veiculos { get; set; } = new();

        public class CnhCommand
        {
            public string Numero { get; set; } = string.Empty;
            public string? EstadoEmissao { get; set; }
            public DateTime DataVencimento { get; set; }
            public string Categoria { get; set; } = string.Empty;
            public string? CodigoCidade { get; set; }
            public string? CodigoSeguranca { get; set; }
            public DateTime? DataPrimeiraHabilitacao { get; set; }
            public string? Imagem { get; set; }
        }

        public class MotoristaCommand
        {
            public string Nome { get; set; } = string.Empty;
            public string Genero { get; set; } = string.Empty;
            public DateTime DataNascimento { get; set; }
            public string Cpf { get; set; } = string.Empty;
            public string Rg { get; set; } = string.Empty;
            public string? EstadoEmissao { get; set; }
            public DateTime DataEmissao { get; set; }
            public CnhCommand Cnh { get; set; } = new();
            public string NomeMae { get; set; } = string.Empty;
            public string? NomePai { get; set; }
            public string Telefone { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string? NomeReferencia { get; set; }
            public string? TelefoneReferencia { get; set; }
            public string Cep { get; set; } = string.Empty;
            public string CodigoCidade { get; set; } = string.Empty;
            public string? NomeCidade { get; set; }
            public string? Rua { get; set; }
            public string Numero { get; set; } = string.Empty;
            public string? Complemento { get; set; }
            public string? Bairro { get; set; }
            public string? Estado { get; set; }
        }

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
            public ProprietarioCommand Proprietario { get; set; } = new();
            public string? ImagemCrlv { get; set; }
        }

    }
}