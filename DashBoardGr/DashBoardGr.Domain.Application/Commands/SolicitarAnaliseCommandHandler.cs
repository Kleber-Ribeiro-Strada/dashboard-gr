using DashBoardGr.Infrastructure.Messaging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Commands
{
    public class SolicitarAnaliseCommandHandler : IRequestHandler<SolicitarAnaliseCommand, Unit>
    {
        private readonly IMessageBusService _messageBusService;
        public SolicitarAnaliseCommandHandler(IMessageBusService messageBusService)
        {
            _messageBusService = messageBusService;
        }


        public Task<Unit> Handle(SolicitarAnaliseCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Kleber Ribeiro");

            _messageBusService.Publish(request, "fila-fila");

            return Task.FromResult(Unit.Value);
        }
    }
}
