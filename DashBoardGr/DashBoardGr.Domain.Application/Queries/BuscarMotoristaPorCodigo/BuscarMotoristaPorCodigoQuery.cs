using DashBoardGr.Domain.Application.Queries.AnaliseQueries.BuscarAnalise;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Queries.BuscarMotoristaPorCodigo
{
    public class BuscarMotoristaPorCodigoQuery : IRequest<BuscarMotoristaViewModel>
    {
        public Guid Id{ get; set; }
    }
}
