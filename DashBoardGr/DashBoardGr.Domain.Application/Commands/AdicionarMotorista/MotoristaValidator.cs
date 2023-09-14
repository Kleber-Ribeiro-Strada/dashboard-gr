using DashBoardGr.Domain.Application.Commands.SolicitarAnalise;
using DashBoardGr.Domain.Shared.Validator;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Commands.AdicionarMotorista
{
    public class MotoristaValidator : AbstractValidator<AdicionarMotoristaCommand>
    {
        public MotoristaValidator()
        {
            RuleFor(analise => analise.Nome)
                .NotNull()
                .NotEmpty()
                .WithMessage(analise => "Campo Nome é obrigatório");

            RuleFor(analise => analise.Genero)
                .NotEmpty()
                .NotNull()
                .WithMessage("Campo gênero é Obrigatório")
                .NotEqual("M")
                .NotEqual("F")
                .WithMessage("Campo gênero tem que ser Masculino ou Feminino");

            RuleFor(analise => analise.DataNascimento)
                .Must(SharedValidators.EhMaiorDe18Anos)
                .WithMessage("Só é permitiro motoristas maiores de 18 anos");

            RuleFor(analise => analise.Cpf)
                .NotEmpty()
                .WithMessage("Campo CPF é obrigatório")
                .IsValidCPF()
                .WithMessage("Campo CPF inválido");

            RuleFor(analise => analise.NomeMae)
                .NotEmpty()
                .WithMessage("Campo Nome da Mãe é obrigatório");

            RuleFor(analise => analise.Email)
                .NotEmpty()
                .WithMessage("Campo E-mail é obrigatóriO")
                .EmailAddress().WithMessage("O endereço de e-mail não é válido.");

            RuleFor(analise => analise.Cep)
                .NotEmpty()
                .WithMessage("Campo CEP é obrigatório");

            RuleFor(analise => analise.Numero)
                .NotEmpty()
                .WithMessage("Capmo Número Residência é obrigatório");
        }


    }
}
