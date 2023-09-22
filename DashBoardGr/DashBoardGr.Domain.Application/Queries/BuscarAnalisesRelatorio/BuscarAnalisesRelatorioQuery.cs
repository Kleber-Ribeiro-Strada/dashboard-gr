using DashBoardGr.Domain.Application.Queries.BuscarMotoristaPorCodigo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Queries.BuscarAnalisesRelatorio
{
    public class BuscarAnalisesRelatorioQuery : IRequest<List<BuscarAnalisesGraficoViewModel>>
    {
        public DateTime? DataSolicitacaoDe { get; set; }

        public DateTime? DataSolicitacaoAte { get; set; }

        public string? Cpf { get; set; }

        public string? Status { get; set; }


    }
}
