using Azure.Core;
using DashBoardGr.Domain.Application.Commands.AdicionarMotorista;
using DashBoardGr.Domain.Application.Enums;
using DashBoardGr.Domain.Repository.Repositories.Interfaces;
using DashBoardGr.Domain.Shared;
using DashBoardGr.Domain.Shared.Commands.Response;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Commands.AvaliarAnalise
{
    public class AvaliarAnaliseCommandHandler : IRequestHandler<AvaliarAnaliseCommand, CommandResponse>
    {
        private readonly IAnaliseRiscoRepository _analiseRiscoRepository;
        private readonly IValidator<AvaliarAnaliseCommand> _validator;
        public AvaliarAnaliseCommandHandler(IAnaliseRiscoRepository analiseRiscoRepository, IValidator<AvaliarAnaliseCommand> validator)
        {
            _analiseRiscoRepository = analiseRiscoRepository;
            _validator = validator;
        }

        public async Task<CommandResponse> Handle(AvaliarAnaliseCommand request, CancellationToken cancellationToken)
        {
            var result = await _validator.ValidateAsync(request, cancellationToken);
            if (!result.IsValid)
                return new CommandResponse(400, "Requisição inválida", result.Errors);
            
            await _analiseRiscoRepository.Avaliar(
                request.Id,
                 request.Status.ObterDescricaoDoEnum(),
                request.Motivo.ObterDescricaoDoEnum(),
                request.Observacao);

            return null;
        }
    }
}
