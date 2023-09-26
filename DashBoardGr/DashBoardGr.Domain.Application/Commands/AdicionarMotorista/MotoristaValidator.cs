using DashBoardGr.Domain.Repository.Repositories.Interfaces;
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
        private readonly IMotoristaRepository _motoristaRepository;
        
        
        public MotoristaValidator(IMotoristaRepository motoristaRepository)
        {
            _motoristaRepository = motoristaRepository;
            
            RuleFor(motorista => motorista.Nome)
                .NotNull()
                .NotEmpty()
                .WithMessage(motorista => "Campo Nome é obrigatório");

            RuleFor(motorista => motorista.Genero)
                .NotEmpty()
                .NotNull()
                .WithMessage("Campo gênero é Obrigatório")
                .Must(SharedValidators.ValidarGenero)
                .WithMessage("Campo gênero tem que ser Masculino ou Feminino (M ou F)");

            RuleFor(motorista => motorista.DataNascimento)
                .Must(SharedValidators.EhMaiorDe18Anos)
                .WithMessage("Só é permitiro motoristas maiores de 18 anos");

            RuleFor(motorista => motorista.Cpf)
                .NotEmpty()
                .WithMessage("Campo CPF é obrigatório")
                .IsValidCPF()
                .WithMessage("Campo CPF inválido")
                .Must(EhNovoCpf)
                .WithMessage("CPF já cadastrado na base");

            RuleFor(motorista => motorista.NomeMae)
                .NotEmpty()
                .WithMessage("Campo Nome da Mãe é obrigatório");

            RuleFor(motorista => motorista.Email)
                .NotEmpty()
                .WithMessage("Campo E-mail é obrigatório")
                .EmailAddress().WithMessage("O endereço de e-mail não é válido.");

            RuleFor(motorista => motorista.Cep)
                .NotEmpty()
                .WithMessage("Campo CEP é obrigatório");

            RuleFor(motorista => motorista.Numero)
                .NotEmpty()
                .WithMessage("Campo Número Residência é obrigatório");
        }

        private bool EhNovoCpf(string cpf)
        {
            return !_motoristaRepository.MotoristaExistente(cpf);
        }
    }
}
