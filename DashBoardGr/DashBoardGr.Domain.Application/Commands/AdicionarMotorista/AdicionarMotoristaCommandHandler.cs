using DashBoardGr.Domain.Application.Commands.SolicitarAnalise;
using DashBoardGr.Domain.Repository.Entities;
using DashBoardGr.Domain.Repository.Repositories.Interfaces;
using DashBoardGr.Domain.Shared.Commands.Response;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Commands.AdicionarMotorista
{
    public class AdicionarMotoristaCommandHandler : IRequestHandler<AdicionarMotoristaCommand, CommandResponse>
    {
        private readonly IMotoristaRepository _motoristaRepository;
        private readonly IMediator _mediator;
        private readonly IValidator<AdicionarMotoristaCommand> _validator;


        public AdicionarMotoristaCommandHandler(IMotoristaRepository motoristaRepository, IMediator mediator, IValidator<AdicionarMotoristaCommand> validator)
        {
            _motoristaRepository = motoristaRepository;
            _mediator = mediator;
            _validator = validator;
        }


        public async Task<CommandResponse> Handle(AdicionarMotoristaCommand request, CancellationToken cancellationToken)
        {
            
            var result = await _validator.ValidateAsync(request, cancellationToken);
            if (!result.IsValid)
                return new CommandResponse(400, "Requisição inválida", result.Errors);
            
            var motorista = new Motorista(
                request.Nome
                , request.Genero
                , request.DataNascimento
                , request.Cpf
                , request.Rg
                , request.EstadoEmissao
                , request.DataEmissao
                , request.NomeMae
                , request.NomePai
                , request.Telefone
                , request.Email
                , request.NomeReferencia
                , request.TelefoneReferencia
                , request.Cep
                , request.CodigoCidade
                , request.NomeCidade
                , request.Rua
                , request.Complemento
                , request.Estado
                , request.Bairro
                , request.Numero);

            await _motoristaRepository.AddAsync(motorista);

            await _mediator.Publish(new MotoristaAdicionadoEvent
            {
                Nome = request.Nome,
                Cpf = request.Cpf,
                Email = request.Email,
                Telefone = request.Telefone,
            });

            return new CommandResponse(motorista);
        }
    }
}
