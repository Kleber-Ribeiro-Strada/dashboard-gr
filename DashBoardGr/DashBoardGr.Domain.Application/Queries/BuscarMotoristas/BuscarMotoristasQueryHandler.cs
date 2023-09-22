using AutoMapper;
using DashBoardGr.Domain.Application.Queries.BuscarMotoristaPorCodigo;
using DashBoardGr.Domain.Repository.Entities;
using DashBoardGr.Domain.Repository.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Queries.BuscarMotoristas
{
    public class BuscarMotoristasQueryHandler : IRequestHandler<BuscarMotoristasQuery, List<BuscarMotoristasViewModel>>
    {
        private readonly IMotoristaRepository _repository;
        private readonly IMapper _mapper;

        public BuscarMotoristasQueryHandler(IMotoristaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<BuscarMotoristasViewModel>> Handle(BuscarMotoristasQuery request, CancellationToken cancellationToken)
        {
            var motoristas = await _repository.GetAll();
                
            return _mapper.Map<List<BuscarMotoristasViewModel>>(motoristas.ToList());
        }
    }
}
