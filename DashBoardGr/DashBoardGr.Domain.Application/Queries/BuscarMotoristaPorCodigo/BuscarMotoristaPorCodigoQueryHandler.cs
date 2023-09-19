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
    public class BuscarMotoristaPorCodigoQueryHandler : IRequestHandler<BuscarMotoristaPorCodigoQuery, BuscarMotoristasViewModel>
    {
        private readonly IMotoristaRepository _motoristaRepository;

        public BuscarMotoristaPorCodigoQueryHandler(IMotoristaRepository motoristaRepository)
        {
            _motoristaRepository = motoristaRepository;
        }



        public async Task<BuscarMotoristasViewModel> Handle(BuscarMotoristaPorCodigoQuery request, CancellationToken cancellationToken)
        {
            var motorista = await _motoristaRepository.Get(request.Id);

            return new BuscarMotoristasViewModel();
        }
    }
}
