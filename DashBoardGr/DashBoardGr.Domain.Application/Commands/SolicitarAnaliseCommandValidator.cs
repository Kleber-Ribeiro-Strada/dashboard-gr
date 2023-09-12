using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Commands
{
    public class SolicitarAnaliseCommandValidator : AbstractValidator<SolicitarAnaliseCommand>
    {
        public SolicitarAnaliseCommandValidator()
        {
            RuleFor(analise => analise.Motorista.Nome)
                .NotNull()
                .NotEmpty()
                .WithMessage(analise => "Campo Nome é obrigatório");

            RuleFor(analise => analise.Motorista.Genero)
                .NotEmpty()
                .NotNull()
                .WithMessage("Campo gênero é Obrigatório")
                .NotEqual("M")
                .NotEqual("F")
                .WithMessage("Campo gênero tem que ser Masculino ou Feminino");

            RuleFor(analise => analise.Motorista.DataNascimento)
                .Must(EhMaiorDe18Anos)
                .WithMessage("Só é permitiro motoristas maiores de 18 anos");

            RuleFor(analise => analise.Motorista.Cpf)
                .NotEmpty()
                .WithMessage("Campo CPF é obrigatório")
                .IsValidCPF()
                .WithMessage("Campo CPF inválido");

            RuleFor(analise => analise.Motorista.NomeMae)
                .NotEmpty()
                .WithMessage("Campo Nome da Mãe é obrigatório");

            RuleFor(analise => analise.Motorista.Email)
                .NotEmpty()
                .WithMessage("Campo E-mail é obrigatóriO")
                .EmailAddress().WithMessage("O endereço de e-mail não é válido.");

            RuleFor(analise => analise.Motorista.Cep)
                .NotEmpty()
                .WithMessage("Campo CEP é obrigatório");

            RuleFor(analise => analise.Motorista.Numero)
                .NotEmpty()
                .WithMessage("Capmo Número Residência é obrigatório");
        }

        private bool EhMaiorDe18Anos(DateTime dataNascimento)
        {
            var idade = DateTime.Today.Year - dataNascimento.Year;
            if (dataNascimento.Date > DateTime.Today.AddYears(-idade)) idade--;

            return idade >= 18;
        }
    }
}
