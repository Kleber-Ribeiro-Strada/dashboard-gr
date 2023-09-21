using AutoMapper;
using DashBoardGr.Domain.Application.Queries.AnaliseQueries.BuscarAnalise;
using DashBoardGr.Domain.Repository.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Queries.BuscarMotoristaPorCodigo
{
    public class BuscarMotoristaPorCodigoQueryHandler : IRequestHandler<BuscarMotoristaPorCodigoQuery, BuscarMotoristaViewModel>
    {
        private readonly IMotoristaRepository _motoristaRepository;
        private readonly IMapper _mapper;

        public BuscarMotoristaPorCodigoQueryHandler(IMotoristaRepository motoristaRepository, IMapper mapper)
        {
            _motoristaRepository = motoristaRepository;
            _mapper = mapper;
        }



        public async Task<BuscarMotoristaViewModel> Handle(BuscarMotoristaPorCodigoQuery request, CancellationToken cancellationToken)
        {
            var motorista = await _motoristaRepository.Get(request.Id);

            return _mapper.Map<BuscarMotoristaViewModel>(motorista);
        }
    }
}
