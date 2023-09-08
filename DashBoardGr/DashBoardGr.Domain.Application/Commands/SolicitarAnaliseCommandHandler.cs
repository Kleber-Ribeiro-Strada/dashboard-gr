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
        public Task<Unit> Handle(SolicitarAnaliseCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Kleber Ribeiro");

            return Task.FromResult(Unit.Value);
        }
    }
}
