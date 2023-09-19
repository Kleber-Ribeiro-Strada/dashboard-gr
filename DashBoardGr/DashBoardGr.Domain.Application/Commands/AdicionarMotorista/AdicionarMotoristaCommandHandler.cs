using AutoMapper;
using DashBoardGr.Domain.Repository.Entities;
using DashBoardGr.Domain.Repository.Repositories.Interfaces;
using DashBoardGr.Domain.Shared.Commands.Response;
using DashBoardGr.Infrastructure.BuscarCep.ExternalServices;
using FluentValidation;
using MediatR;

namespace DashBoardGr.Domain.Application.Commands.AdicionarMotorista
{
    public class AdicionarMotoristaCommandHandler : IRequestHandler<AdicionarMotoristaCommand, CommandResponse>
    {
        private readonly IMotoristaRepository _motoristaRepository;
        private readonly IMediator _mediator;
        private readonly IValidator<AdicionarMotoristaCommand> _validator;
        private readonly BuscarEnderecoService _buscarEnderecoService;
        private readonly IMapper _mapper;

        public AdicionarMotoristaCommandHandler(IMotoristaRepository motoristaRepository, IMediator mediator, IValidator<AdicionarMotoristaCommand> validator, BuscarEnderecoService buscarEnderecoService, IMapper mapper)
        {
            _motoristaRepository = motoristaRepository;
            _mediator = mediator;
            _validator = validator;
            _buscarEnderecoService = buscarEnderecoService;
            _mapper = mapper;
        }


        public async Task<CommandResponse> Handle(AdicionarMotoristaCommand request, CancellationToken cancellationToken)
        {
            var result = await _validator.ValidateAsync(request, cancellationToken);
            if (!result.IsValid)
                return new CommandResponse(400, "Requisição inválida", result.Errors);


            var endereco = await _buscarEnderecoService.BuscarEndereco(request.Cep);
            if (endereco == null)
                return new CommandResponse(400, "Cep inesistente", data: new {});

            request.CodigoCidade = endereco.Gia;
            request.NomeCidade = endereco.Localidade;
            request.Rua = endereco.Logradouro;
            request.Estado = endereco.Uf;
            request.Bairro = endereco.Bairro;

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

            return new CommandResponse(motorista);
        }
    }
}
