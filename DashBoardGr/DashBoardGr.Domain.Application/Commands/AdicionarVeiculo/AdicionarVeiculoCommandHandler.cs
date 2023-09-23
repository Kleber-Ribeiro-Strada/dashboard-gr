using DashBoardGr.Domain.Application.Commands.AdicionarMotorista;
using DashBoardGr.Domain.Application.Commands.SolicitarAnalise;
using DashBoardGr.Domain.Repository.Entities;
using DashBoardGr.Domain.Repository.Repositories.Interfaces;
using DashBoardGr.Domain.Shared.Commands.Response;
using DashBoardGr.Infrastructure.BuscarCep.ExternalServices;
using FluentValidation;
using MediatR;

namespace DashBoardGr.Domain.Application.Commands.AdicionarVeiculo
{
    public class AdicionarVeiculoCommandHandler : IRequestHandler<AdicionarVeiculoCommand, CommandResponse>
    {
        private readonly IMotoristaRepository _motoristaRepository;
        private readonly IValidator<AdicionarVeiculoCommand> _validator;
        public AdicionarVeiculoCommandHandler(IMotoristaRepository motoristaRepository, IValidator<AdicionarVeiculoCommand> validator)
        {
            _motoristaRepository = motoristaRepository;
            _validator = validator;
        }

        public async Task<CommandResponse> Handle(AdicionarVeiculoCommand request, CancellationToken cancellationToken)
        {
            var result = await _validator.ValidateAsync(request, cancellationToken);
            if (!result.IsValid)
                return new CommandResponse(400, "Requisição inválida", result.Errors);


            return new CommandResponse(new { });
        }
    }
}
