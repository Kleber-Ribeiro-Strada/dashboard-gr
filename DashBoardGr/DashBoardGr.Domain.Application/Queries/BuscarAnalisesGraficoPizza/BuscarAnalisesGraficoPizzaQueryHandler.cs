using AutoMapper;
using DashBoardGr.Domain.Application.Queries.BuscarAnalisesRelatorio;
using DashBoardGr.Domain.Repository.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Queries.BuscarAnalisesGraficoPizza
{
    public class BuscarAnalisesGraficoPizzaQueryHandler : IRequestHandler<BuscarAnalisesGraficoPizzaQuery, BuscarAnalisesGraficoPizzaViewModel>
    {
        private readonly IAnaliseRiscoRepository _repository;
        private readonly IMapper _mapper;
        public BuscarAnalisesGraficoPizzaQueryHandler(IAnaliseRiscoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BuscarAnalisesGraficoPizzaViewModel> Handle(BuscarAnalisesGraficoPizzaQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.BuscarGraficoBarra(request.DataSolicitacaoDe, request.DataSolicitacaoAte);
            if (result == null)
            {
                return new BuscarAnalisesGraficoPizzaViewModel();
            }
            return _mapper.Map<BuscarAnalisesGraficoPizzaViewModel>(result);
        }
    }
}
