using DashBoardGr.Domain.Shared.Commands.Response;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Shared.Commands.Request
{
    public abstract class CommandRequest : IRequest<CommandResponse>
    {
    }
}
