using AutoMapper;
using DashBoardGr.Domain.Application.Queries.BuscarMotoristaPorCodigo;
using DashBoardGr.Domain.Repository.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Queries.BuscarAnalisesRelatorio
{
    public class BuscarAnalisesRelatorioQueryHandler : IRequestHandler<BuscarAnalisesRelatorioQuery, List<BuscarAnalisesGraficoViewModel>>
    {
        private readonly IAnaliseRiscoRepository _analiseRepository;
        private readonly IMapper _mapper;
        public BuscarAnalisesRelatorioQueryHandler(
            IAnaliseRiscoRepository analiseRepository,
            IMapper mapper)
        {
            _analiseRepository = analiseRepository;
            _mapper = mapper;
        }

        public async Task<List<BuscarAnalisesGraficoViewModel>> Handle(BuscarAnalisesRelatorioQuery request, CancellationToken cancellationToken)
        {
            var analises = await _analiseRepository.BuscarAnalisesAnalisesRisco(
                request.DataSolicitacaoDe,
                request.DataSolicitacaoAte,
                request.Cpf,
                request.Status);

            var result = _mapper.Map<List<BuscarAnalisesGraficoViewModel>>(analises.ToList());
            result.Count(x => x.Status == "Pendente");
            return result;
        }


    }
}
