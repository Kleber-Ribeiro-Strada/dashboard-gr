using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Queries.BuscarAnalisesGraficoPizza
{
    public class BuscarAnalisesGraficoPizzaQuery : IRequest<BuscarAnalisesGraficoPizzaViewModel>
    {
        public DateTime? DataSolicitacaoDe { get; set; }

        public DateTime? DataSolicitacaoAte { get; set; }
    }
}
