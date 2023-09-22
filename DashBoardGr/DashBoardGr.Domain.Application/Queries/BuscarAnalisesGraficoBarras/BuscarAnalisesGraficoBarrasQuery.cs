using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Queries.BuscarAnalisesGraficoBarras
{
    public class BuscarAnalisesGraficoBarrasQuery : IRequest<BuscarAnalisesGraficoBarrasViewModel>
    {
        public DateTime? DataSolicitacaoDe { get; set; }

        public DateTime? DataSolicitacaoAte { get; set; }
    }
}
