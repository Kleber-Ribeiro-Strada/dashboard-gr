using AutoMapper;
using DashBoardGr.Domain.Application.Queries.BuscarAnalisesGraficoPizza;
using DashBoardGr.Domain.Application.Queries.BuscarAnalisesRelatorio;
using DashBoardGr.Domain.Repository.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Queries.BuscarAnalisesGraficoLinha
{
    public class BuscarAnalisesGraficoLinhaQueryHandler : IRequestHandler<BuscarAnalisesGraficoLinhaQuery, BuscarAnalisesGraficoLinhaViewModel>
    {
        private readonly IAnaliseRiscoRepository _repository;
        private readonly IMapper _mapper;
        public BuscarAnalisesGraficoLinhaQueryHandler(IAnaliseRiscoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BuscarAnalisesGraficoLinhaViewModel> Handle(BuscarAnalisesGraficoLinhaQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.BuscarGraficoPorHora(request.DataSolicitacaoDe, request.DataSolicitacaoAte);
            if (result == null)
            {
                return new BuscarAnalisesGraficoLinhaViewModel();
            }
            return _mapper.Map<BuscarAnalisesGraficoLinhaViewModel>(result);
        }
    }
}
