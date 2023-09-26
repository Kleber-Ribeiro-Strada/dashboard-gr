using AutoMapper;
using DashBoardGr.Domain.Repository.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Queries.AnaliseQueries.BuscarAnalise
{
    public class BuscarAnaliseQueryHandler : IRequestHandler<BuscarAnaliseQuery, BuscarAnaliseViewModel>
    {
        private readonly IAnaliseRiscoRepository _analiseRiscoRepository;
        private readonly IMapper _mapper;
        public BuscarAnaliseQueryHandler(IAnaliseRiscoRepository analiseRiscoRepository, IMapper mapper)
        {
            _analiseRiscoRepository = analiseRiscoRepository;
            _mapper = mapper;
        }

        public async Task<BuscarAnaliseViewModel> Handle(BuscarAnaliseQuery request, CancellationToken cancellationToken)
        {
            var result = await _analiseRiscoRepository.BuscarAnaliseRisco(request.Id);

            return _mapper.Map<BuscarAnaliseViewModel>(result);
        }
    }
}
