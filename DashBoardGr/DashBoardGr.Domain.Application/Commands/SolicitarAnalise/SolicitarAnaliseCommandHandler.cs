using DashBoardGr.Infrastructure.Messaging;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Commands.SolicitarAnalise
{
    public class SolicitarAnaliseCommandHandler : IRequestHandler<SolicitarAnaliseCommand, Unit>
    {
        private readonly IMessageBusService _messageBusService;
        private readonly IValidator<SolicitarAnaliseCommand> _validator;
        public SolicitarAnaliseCommandHandler(IMessageBusService messageBusService, IValidator<SolicitarAnaliseCommand> validator)
        {
            _messageBusService = messageBusService;
            _validator = validator;
        }


        public async Task<Unit> Handle(SolicitarAnaliseCommand request, CancellationToken cancellationToken)
        {
            var result = await _validator.ValidateAsync(request, cancellationToken);

            if (!result.IsValid)
            {
                return Unit.Value;
            }

            await _messageBusService.Publish(request);
            return Unit.Value;



        }
    }
}
