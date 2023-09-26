using AutoMapper;
using DashBoardGr.Domain.Repository.Entities;
using DashBoardGr.Domain.Repository.Repositories.Interfaces;
using DashBoardGr.Domain.Shared.Commands.Response;
using FluentValidation;
using MediatR;

namespace DashBoardGr.Domain.Application.Commands.AdicionarMotorista
{
    public class AdicionarMotoristaCommandHandler : IRequestHandler<AdicionarMotoristaCommand, CommandResponse>
    {
        private readonly IMotoristaRepository _motoristaRepository;
        private readonly IMediator _mediator;
        private readonly IValidator<AdicionarMotoristaCommand> _validator;
        private readonly IMapper _mapper;

        public AdicionarMotoristaCommandHandler(IMotoristaRepository motoristaRepository, IMediator mediator, IValidator<AdicionarMotoristaCommand> validator, IMapper mapper)
        {
            _motoristaRepository = motoristaRepository;
            _mediator = mediator;
            _validator = validator;
            _mapper = mapper;
        }


        public async Task<CommandResponse> Handle(AdicionarMotoristaCommand request, CancellationToken cancellationToken)
        {
            var result = await _validator.ValidateAsync(request, cancellationToken);
            if (!result.IsValid)
                return new CommandResponse(400, "Requisição inválida", result.Errors);

            var motorista = _mapper.Map<Motorista>(request);
            request.Cnh.MotoristaId = motorista.Id;

            var cnh = _mapper.Map<Cnh>(request.Cnh);            

            await _motoristaRepository.AddAsync(motorista, cnh);

            await _mediator.Publish(new MotoristaAdicionadoEvent
            {
                Nome = request.Nome,
                Cpf = request.Cpf,
                Email = request.Email,
                Telefone = request.Telefone,
            }, cancellationToken);

            return new CommandResponse(motorista.Id);
        }
    }
}
