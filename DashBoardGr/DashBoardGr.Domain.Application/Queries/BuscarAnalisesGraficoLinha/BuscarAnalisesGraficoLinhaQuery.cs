using DashBoardGr.Domain.Application.Queries.BuscarAnalisesGraficoLinha;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Queries.BuscarAnalisesGraficoPizza
{
    public class BuscarAnalisesGraficoLinhaQuery : IRequest<BuscarAnalisesGraficoLinhaViewModel>
    {
        public DateTime? DataSolicitacaoDe { get; set; }

        public DateTime? DataSolicitacaoAte { get; set; }
    }
}
