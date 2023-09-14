using DashBoardGr.Domain.Shared.Commands.Request;
using System.Text.Json.Serialization;
using static DashBoardGr.Domain.Application.Commands.SolicitarAnalise.SolicitarAnaliseCommand;

namespace DashBoardGr.Domain.Application.Commands.AdicionarMotorista
{
    public class AdicionarMotoristaCommand: CommandRequest
    {
        public string Nome { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; } = string.Empty;
        public string Rg { get; set; } = string.Empty;
        public string? EstadoEmissao { get; set; }
        public DateTime DataEmissao { get; set; }
        public string NomeMae { get; set; } = string.Empty;
        public string? NomePai { get; set; }
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? NomeReferencia { get; set; }
        public string? TelefoneReferencia { get; set; }
        public string Cep { get; set; } = string.Empty;

        [JsonIgnore]
        public string? CodigoCidade { get; set; }

        [JsonIgnore]
        public string? NomeCidade { get; set; }

        [JsonIgnore]
        public string? Rua { get; set; }
        public string Numero { get; set; } = string.Empty;
        public string? Complemento { get; set; }

        [JsonIgnore]
        public string? Bairro { get; set; }

        [JsonIgnore]
        public string? Estado { get; set; }

        public AdicionarCnhMotoristaCommand Cnh { get; set; } = new();
    }

    public class AdicionarCnhMotoristaCommand
    {

        public string Numero { get; set; } = string.Empty;
        public string? EstadoEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Categoria { get; set; } = string.Empty;

        [JsonIgnore]
        public string? CodigoCidade { get; set; }
        public string? CodigoSeguranca { get; set; }
        public DateTime? DataPrimeiraHabilitacao { get; set; }
        public string? Imagem { get; set; }
    }
}
