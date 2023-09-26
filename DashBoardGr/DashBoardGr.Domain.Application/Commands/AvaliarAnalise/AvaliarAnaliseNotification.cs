using DashBoardGr.Domain.Application.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Commands.AvaliarAnalise
{
    public class AvaliarAnaliseNotification : INotification
    {
        public Guid Id { get; set; }

        public EStatus Status { get; set; }

        public EMotivo? Motivo { get; set; }

        public string? Observacao { get; set; }
    }
}
