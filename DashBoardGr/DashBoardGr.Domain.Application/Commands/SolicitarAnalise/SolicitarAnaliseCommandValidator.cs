using FluentValidation;

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
                    .NotEmpty()
                    .WithMessage("O CPF/CNPJ do proprietário é obrigatório.");

                RuleFor(proprietario => proprietario.Nome)
                    .NotEmpty()
                    .WithMessage("O Nome do proprietário é obrigatório.");

                RuleFor(proprietario => proprietario.Cep)
                    .NotEmpty()
                    .WithMessage("O Cep do proprietário é obrigatório.");

                RuleFor(proprietario => proprietario.Numero)
                    .NotNull()
                    .WithMessage("O Número do proprietário é obrigatório.");

                RuleFor(proprietario => proprietario.CodigoCidade)
                    .NotEmpty()
                    .WithMessage("O CodigoCidade do proprietário é obrigatório.");

                RuleFor(proprietario => proprietario.NomeCidade)
                    .NotEmpty()
                    .WithMessage("O NomeCidade do proprietário é obrigatório.");

                RuleFor(proprietario => proprietario.Rua)
                    .NotEmpty()
                    .WithMessage("O Rua do proprietário é obrigatório.");

                RuleFor(proprietario => proprietario.Bairro)
                    .NotEmpty()
                    .WithMessage("O Bairro do proprietário é obrigatório.");

                RuleFor(proprietario => proprietario.Estado)
                    .NotEmpty()
                    .WithMessage("O Estado do proprietário é obrigatório.");

                RuleFor(proprietario => proprietario.Telefone)
                    .NotEmpty()
                    .WithMessage("O Telefone do proprietário é obrigatório.");

            }
        }

        public class VeiculoCommandValidator : AbstractValidator<SolicitarAnaliseCommand.VeiculoCommand>
        {
            public VeiculoCommandValidator()
            {
                RuleFor(veiculo => veiculo.Tipo)
                    .NotEmpty().WithMessage("O tipo do veículo é obrigatório.");

                RuleFor(veiculo => veiculo.Placa)
                    .NotEmpty().WithMessage("A placa do veículo é obrigatório.");

                RuleFor(veiculo => veiculo.Chassi)
                    .NotEmpty().WithMessage("O Chassi do veículo é obrigatória.");

                RuleFor(veiculo => veiculo.Renavam)
                    .NotEmpty().WithMessage("O Renavam do veículo é obrigatória.");

                RuleFor(veiculo => veiculo.DataLicenciamento)
                    .NotEmpty().WithMessage("A data de licenciamento do veículo é obrigatória.");

                RuleFor(veiculo => veiculo.Cor)
                    .NotEmpty().WithMessage("A Cor do veículo é obrigatória.");

                RuleFor(veiculo => veiculo.Marca)
                    .NotEmpty().WithMessage("A marca do veículo é obrigatória.");

                RuleFor(veiculo => veiculo.Modelo)
                    .NotEmpty().WithMessage("o Modelo do veículo é obrigatória.");

                RuleFor(veiculo => veiculo.AnoFabricacao)
                    .NotEmpty().WithMessage("o AnoFabricacao do veículo é obrigatória.");

                RuleFor(veiculo => veiculo.AnoModelo)
                    .NotEmpty().WithMessage("O ano modelo do veículo é obrigatória.");

                RuleFor(veiculo => veiculo.Estado)
                    .NotEmpty().WithMessage("O estado do veículo é obrigatória.");



            }
        }
    }
}
