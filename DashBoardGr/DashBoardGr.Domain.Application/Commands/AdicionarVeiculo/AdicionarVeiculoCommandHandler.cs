using DashBoardGr.Domain.Application.Commands.AdicionarMotorista;
using DashBoardGr.Domain.Application.Commands.SolicitarAnalise;
using DashBoardGr.Domain.Repository.Entities;
using DashBoardGr.Domain.Repository.Repositories.Interfaces;
using DashBoardGr.Domain.Shared.Commands.Response;
using DashBoardGr.Infrastructure.BuscarCep.ExternalServices;
using FluentValidation;
using MediatR;

namespace DashBoardGr.Domain.Application.Commands.AdicionarVeiculo
{
    public class AdicionarVeiculoCommandHandler : IRequestHandler<AdicionarVeiculoCommand, CommandResponse>
    {
        private readonly IMotoristaRepository _motoristaRepository;
        private readonly IValidator<AdicionarVeiculoCommand> _validator;
        private readonly BuscarEnderecoService _buscarEnderecoService;
        public AdicionarVeiculoCommandHandler(IMotoristaRepository motoristaRepository, IValidator<AdicionarVeiculoCommand> validator, BuscarEnderecoService buscarEnderecoService)
        {
            _motoristaRepository = motoristaRepository;
            _validator = validator;
            _buscarEnderecoService = buscarEnderecoService;
        }

        public async Task<CommandResponse> Handle(AdicionarVeiculoCommand request, CancellationToken cancellationToken)
        {
            var result = await _validator.ValidateAsync(request, cancellationToken);
            if (!result.IsValid)
                return new CommandResponse(400, "Requisição inválida", result.Errors);

            var endereco = await _buscarEnderecoService.BuscarEndereco(request.Proprietario.Cep);
            if (endereco == null)
            {
                return new CommandResponse(400, "Requisição inválida", "CEP não encontrado");
            }

            request.Proprietario.CodigoCidade = endereco.Gia;
            request.Proprietario.Rua = endereco.Logradouro;
            request.Proprietario.Bairro = endereco.Bairro;
            request.Proprietario.Estado = endereco.Uf;
            var proprietario = new Proprietario();
            //request.Proprietario.CpfCnpj
            //, request.Proprietario.Nome
            //, request.Proprietario.Cep
            //, endereco.Gia
            //, request.Proprietario.Nome
            //, endereco.Logradouro
            //, request.Proprietario.Numero
            //, request.Proprietario.Complemento
            //, endereco.Bairro
            //, endereco.Uf
            //, request.Proprietario.Telefone);

            var veiculo = new Veiculo();
                //proprietario.Id
                //, request.Tipo
                //, request.Placa
                //, request.Chassi
                //, request.Renavam
                //, request.Rntrc
                //, request.DataLicenciamento
                //, request.Cor
                //, request.Marca
                //, request.Modelo
                //, request.AnoFabricacao
                //, request.AnoModelo
                //, request.Estado
                //, endereco.Gia
                //, request.ImagemCrlv);

            await _motoristaRepository.AddVeiculo(proprietario, veiculo);

            return new CommandResponse(new { });
        }
    }
}
