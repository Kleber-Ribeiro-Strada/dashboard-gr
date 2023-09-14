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
    public class BuscarMotoristaQueryHandler : IRequestHandler<BuscarMotoristaQuery, BuscarMotoristaViewModel>
    {
        private readonly IMotoristaRepository _motoristaRepository;

        public BuscarMotoristaQueryHandler(IMotoristaRepository motoristaRepository)
        {
            _motoristaRepository = motoristaRepository;
        }



        public async Task<BuscarMotoristaViewModel> Handle(BuscarMotoristaQuery request, CancellationToken cancellationToken)
        {
            var motorista = await _motoristaRepository.Get(request.Id);

            return new BuscarMotoristaViewModel();
        }
    }
}
