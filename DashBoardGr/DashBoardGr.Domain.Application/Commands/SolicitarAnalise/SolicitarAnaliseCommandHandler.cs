using DashBoardGr.Domain.Application.Enums;
using DashBoardGr.Domain.Repository.Entities;
using DashBoardGr.Domain.Repository.Repositories.Interfaces;
using DashBoardGr.Infrastructure.BuscarCep.ExternalServices;
using DashBoardGr.Infrastructure.Messaging;
using FluentValidation;
using MediatR;

namespace DashBoardGr.Domain.Application.Commands.SolicitarAnalise
{
    public class SolicitarAnaliseCommandHandler : IRequestHandler<SolicitarAnaliseCommand, Unit>
    {
        private readonly IMessageBusService _messageBusService;
        private readonly IValidator<SolicitarAnaliseCommand> _validator;
        private readonly IMotoristaRepository _motoristaRepository;
        private readonly IAnaliseRiscoRepository _analiseRiscoRepository;
        public SolicitarAnaliseCommandHandler(
            IMessageBusService messageBusService,
            IValidator<SolicitarAnaliseCommand> validator,
            IAnaliseRiscoRepository analiseRiscoRepository,
            IMotoristaRepository motoristaRepository)
        {
            _messageBusService = messageBusService;
            _validator = validator;
            _motoristaRepository = motoristaRepository;
            _analiseRiscoRepository = analiseRiscoRepository;
        }


        public async Task<Unit> Handle(SolicitarAnaliseCommand request, CancellationToken cancellationToken)
        {
            var result = await _validator.ValidateAsync(request, cancellationToken);

            if (!result.IsValid)
            {
                return Unit.Value;
            }

            var cnh = await _motoristaRepository.BuscarCnh(request.MotoristaId);
            if (cnh == null)
                throw new ArgumentException("CNH não encontrada para o motorista");
           
            var cnhId = cnh.Id;
            var proprietario = new Proprietario(
                request.Proprietario.CpfCnpj,
                request.Proprietario.Nome,
                request.Proprietario.Cep,
                request.Proprietario.CodigoCidade,
                request.Proprietario.NomeCidade,
                request.Proprietario.Rua,
                request.Proprietario.Complemento,
                request.Proprietario.Bairro,
                request.Proprietario.Estado,
                request.Proprietario.Telefone);

            var veiculos = new List<Veiculo>();
            request.Veiculos.ForEach(v => veiculos.Add(new Veiculo(
                v.Tipo,
                v.Placa,
                v.Chassi,
                v.Renavam,
                v.Rntrc,
                v.DataLicenciamento,
                v.Cor,
                v.Marca,
                v.Modelo,
                v.AnoFabricacao,
                v.AnoModelo,
                v.Estado,
                v.CodigoCidade,
                v.ImagemCrlv,
                proprietario.Id
                )));

            await _motoristaRepository.AddVeiculo(proprietario, veiculos);

            await _analiseRiscoRepository.SolicitarAnaliseRisco(new AnaliseRisco(
                Enum.GetName(typeof(EStatus), value: EStatus.Pendente),
                request.MotoristaId,
                cnhId), veiculos);



            await _messageBusService.Publish(request);
            return Unit.Value;
        }
    }
}
