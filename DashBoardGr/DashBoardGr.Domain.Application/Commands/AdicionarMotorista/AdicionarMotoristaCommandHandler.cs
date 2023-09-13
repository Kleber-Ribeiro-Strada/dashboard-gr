using DashBoardGr.Domain.Repository.Entities;
using DashBoardGr.Domain.Repository.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Commands.AdicionarMotorista
{
    public class AdicionarMotoristaCommandHandler : IRequestHandler<AdicionarMotoristaCommand, Unit>
    {
        private readonly IMotoristaRepository _motoristaRepository;
        private readonly IMediator _mediator;

        public AdicionarMotoristaCommandHandler(IMotoristaRepository motoristaRepository, IMediator mediator)
        {
            _motoristaRepository = motoristaRepository;
            _mediator = mediator;
        }


        public async Task<Unit> Handle(AdicionarMotoristaCommand request, CancellationToken cancellationToken)
        {
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

            return Unit.Value;
        }
    }
}
