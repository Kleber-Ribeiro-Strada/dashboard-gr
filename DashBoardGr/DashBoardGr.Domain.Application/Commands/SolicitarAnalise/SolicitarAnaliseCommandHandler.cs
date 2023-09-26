using DashBoardGr.Domain.Application.Enums;
using DashBoardGr.Domain.Repository.Entities;
using DashBoardGr.Domain.Repository.Repositories.Interfaces;
using DashBoardGr.Domain.Shared.Commands.Response;
using DashBoardGr.Infrastructure.Messaging;
using FluentValidation;
using MediatR;

namespace DashBoardGr.Domain.Application.Commands.SolicitarAnalise
{
    public class SolicitarAnaliseCommandHandler : IRequestHandler<SolicitarAnaliseCommand, CommandResponse>
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


        public async Task<CommandResponse> Handle(SolicitarAnaliseCommand request, CancellationToken cancellationToken)
        {

            request.DataRequisicao = DateTime.Now;
            var resultValidator = await _validator.ValidateAsync(request, cancellationToken);

            if (!resultValidator.IsValid)
            {
                return new CommandResponse(400, "Erro Solicitação análise", resultValidator.Errors.ToArray());
            }

            var cnh = await _motoristaRepository.BuscarCnh(request.MotoristaId);
            if (cnh == null)
            {
                resultValidator.Errors.Add(new FluentValidation.Results.ValidationFailure
                {
                    ErrorMessage = " não encontrada para o motorista"
                });
                return new CommandResponse(400, "CNH não encontrada para o motorista", resultValidator.Errors);
            }

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
                request.Proprietario.Telefone,
                request.Proprietario.Numero);

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

            var analiseResult = await _analiseRiscoRepository.SolicitarAnaliseRisco(new AnaliseRisco(
                Enum.GetName(typeof(EStatus), value: EStatus.Pendente) ?? "Pendente",
                request.MotoristaId,
                cnhId), veiculos);



            var result = new CommandResponse(new
            {
                Id = analiseResult.Id,
                Mensagem = "Análise solicitada com sucesso"
            });
            await _messageBusService.Publish(result);
            return result;

        }
    }
}
