using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Commands.SolicitarAnalise
{
    public class SolicitarAnaliseCommandValidator : AbstractValidator<SolicitarAnaliseCommand>
    {
        public SolicitarAnaliseCommandValidator()
        {
            RuleFor(command => command.DataRequisicao)
                .NotEmpty().WithMessage("A data de requisição é obrigatória.");

            RuleFor(command => command.MotoristaId)
                .NotEqual(Guid.Empty)
                .NotNull()
                .NotEmpty()
                .WithMessage("O ID do motorista é obrigatório.");

            RuleFor(command => command.Proprietario)
                .SetValidator(new ProprietarioCommandValidator());

            RuleForEach(command => command.Veiculos)
                .SetValidator(new VeiculoCommandValidator());
        }

        public class ProprietarioCommandValidator : AbstractValidator<SolicitarAnaliseCommand.ProprietarioCommand>
        {
            public ProprietarioCommandValidator()
            {
                RuleFor(proprietario => proprietario.CpfCnpj)
                    .NotEmpty().WithMessage("O CPF/CNPJ do proprietário é obrigatório.");

            }
        }

        public class VeiculoCommandValidator : AbstractValidator<SolicitarAnaliseCommand.VeiculoCommand>
        {
            public VeiculoCommandValidator()
            {
                RuleFor(veiculo => veiculo.Tipo)
                    .NotEmpty().WithMessage("O tipo do veículo é obrigatório.");

                RuleFor(veiculo => veiculo.DataLicenciamento)
                    .NotEmpty().WithMessage("A data de licenciamento do veículo é obrigatória.");
            }
        }
    }
}
