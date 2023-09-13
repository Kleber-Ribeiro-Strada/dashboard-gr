using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DashBoardGr.Domain.Application.Commands.SolicitarAnalise.SolicitarAnaliseCommand;

namespace DashBoardGr.Domain.Application.Commands.AdicionarMotorista
{
    public class AdicionarMotoristaCommand: IRequest<Unit>
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
}
