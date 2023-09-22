using AutoMapper;
using DashBoardGr.Domain.Application.Queries.BuscarAnalisesRelatorio;
using DashBoardGr.Domain.Repository.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Queries.BuscarAnalisesGraficoBarras
{
    public class BuscarAnalisesGraficoBarrasQueryHandler : IRequestHandler<BuscarAnalisesGraficoBarrasQuery, BuscarAnalisesGraficoBarrasViewModel>
    {
        private readonly IAnaliseRiscoRepository _repository;
        private readonly IMapper _mapper;
        public BuscarAnalisesGraficoBarrasQueryHandler(IAnaliseRiscoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BuscarAnalisesGraficoBarrasViewModel> Handle(BuscarAnalisesGraficoBarrasQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.BuscarGraficoPorSemana(request.DataSolicitacaoDe, request.DataSolicitacaoAte);
            if (result == null)
            {
                return new BuscarAnalisesGraficoBarrasViewModel();
            }
            return _mapper.Map<BuscarAnalisesGraficoBarrasViewModel>(result);
        }
    }
}
