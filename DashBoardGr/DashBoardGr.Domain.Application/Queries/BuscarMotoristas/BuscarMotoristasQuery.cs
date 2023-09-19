using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Queries.BuscarMotoristas
{
    public class BuscarMotoristasQuery: IRequest<List<BuscarMotoristasViewModel>>
    {
    }
}
