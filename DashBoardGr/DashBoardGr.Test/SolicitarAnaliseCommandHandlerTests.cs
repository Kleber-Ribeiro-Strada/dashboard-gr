using Bogus;
using DashBoardGr.Domain.Application.Commands.SolicitarAnalise;
using DashBoardGr.Domain.Repository.Entities;
using DashBoardGr.Domain.Repository.Repositories.Interfaces;
using DashBoardGr.Infrastructure.Messaging;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus.Extensions.Brazil;
using static DashBoardGr.Domain.Application.Commands.SolicitarAnalise.SolicitarAnaliseCommand;
using ValidationResult = FluentValidation.Results.ValidationResult;
using FluentValidation.TestHelper;
using static DashBoardGr.Domain.Application.Commands.SolicitarAnalise.SolicitarAnaliseCommandValidator;

namespace DashBoardGr.Test
{
    public class SolicitarAnaliseCommandHandlerTests
    {
        [Fact]
        public async Task Handle_DeveRetornarUnit_QuandoRequestInvalido()
        {
            // Arrange
            var request = GerarSolicitacao();
            request.MotoristaId = Guid.Empty;

            var validatorMock = new Mock<IValidator<SolicitarAnaliseCommand>>();
            validatorMock.Setup(v => v.ValidateAsync(request, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ValidationResult(new List<ValidationFailure>
                {
                new ValidationFailure("Propriedade", "Mensagem de erro")
                    // Adicione mais erros conforme necessário
                }));

            var motoristaRepositoryMock = new Mock<IMotoristaRepository>();
            var analiseRiscoRepositoryMock = new Mock<IAnaliseRiscoRepository>();
            var messageBusServiceMock = new Mock<IMessageBusService>();

            var handler = new SolicitarAnaliseCommandHandler(
                messageBusServiceMock.Object,
                validatorMock.Object,
                analiseRiscoRepositoryMock.Object,
                motoristaRepositoryMock.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.IsSuccessStatusCode.Should().BeFalse();
            result.Message.Should().Be("Erro Solicitação análise");
            result.StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task Handle_DeveExecutarComSucesso_QuandoRequestValido()
        {
            // Arrange
            var request = GerarSolicitacao();
            request.MotoristaId=  Guid.NewGuid();

            var validatorMock = new Mock<IValidator<SolicitarAnaliseCommand>>();
            validatorMock.Setup(v => v.ValidateAsync(request, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ValidationResult());

            var motoristaRepositoryMock = new Mock<IMotoristaRepository>();
            var analiseRiscoRepositoryMock = new Mock<IAnaliseRiscoRepository>();
            var messageBusServiceMock = new Mock<IMessageBusService>();

            motoristaRepositoryMock.Setup(r => r.BuscarCnh(It.IsAny<Guid>()))
                .ReturnsAsync(new Cnh()); // Substitua por uma CNH válida para o teste

            // Configure os mocks conforme necessário para o seu cenário de teste

            var handler = new SolicitarAnaliseCommandHandler(
                messageBusServiceMock.Object,
                validatorMock.Object,
                analiseRiscoRepositoryMock.Object,
                motoristaRepositoryMock.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Message.Should().BeEmpty();


            
        }

        [Fact]
        public void Should_Have_Error_When_DataRequisicao_Is_Default()
        {
            var validator = new SolicitarAnaliseCommandValidator();
            var command = new SolicitarAnaliseCommand(); // DataRequisicao não definida

            var result = validator.TestValidate(command);

            result.ShouldHaveValidationErrorFor(x => x.DataRequisicao);
        }

        [Fact]
        public void Should_Have_Error_When_MotoristaId_Is_Default()
        {
            var validator = new SolicitarAnaliseCommandValidator();
            var command = new SolicitarAnaliseCommand(); // MotoristaId não definido

            var result = validator.TestValidate(command);

            result.ShouldHaveValidationErrorFor(x => x.MotoristaId);
        }

        [Fact]
        public void Should_Have_Error_When_CpfCnpj_Is_Default()
        {
            var validator = new ProprietarioCommandValidator();
            var proprietario = new SolicitarAnaliseCommand.ProprietarioCommand(); // CpfCnpj não definido

            var result = validator.TestValidate(proprietario);

            result.ShouldHaveValidationErrorFor(x => x.CpfCnpj);
        }

        [Fact]
        public void Should_Have_Error_When_Tipo_Is_Default()
        {
            var validator = new VeiculoCommandValidator();
            var veiculo = new SolicitarAnaliseCommand.VeiculoCommand(); // Tipo não definido

            var result = validator.TestValidate(veiculo);

            result.ShouldHaveValidationErrorFor(x => x.Tipo);
        }

        [Fact]
        public void Should_Have_Error_When_DataLicenciamento_Is_Default()
        {
            var validator = new VeiculoCommandValidator();
            var veiculo = new SolicitarAnaliseCommand.VeiculoCommand(); // DataLicenciamento não definida

            var result = validator.TestValidate(veiculo);

            result.ShouldHaveValidationErrorFor(x => x.DataLicenciamento);
        }



        private SolicitarAnaliseCommand GerarSolicitacao()
        {
            SolicitarAnaliseCommand cmd = new();
            
            int random = (new Random().Next(600) * -1);
            cmd.DataRequisicao = DateTime.Now.AddDays(random);

            var fakerPro = new Faker<ProprietarioCommand>("pt_BR")
                .RuleFor(p => p.CpfCnpj, f => f.Person.Cpf())
                .RuleFor(p => p.Nome, f => f.Person.FullName)
                .RuleFor(p => p.Cep, f => f.Address.ZipCode())
                .RuleFor(p => p.CodigoCidade, f => f.Address.CityPrefix())
                .RuleFor(p => p.NomeCidade, f => f.Address.City())
                .RuleFor(p => p.Rua, f => f.Address.StreetName())
                .RuleFor(p => p.Bairro, f => f.Address.Direction())
                .RuleFor(p => p.Complemento, f => f.Address.SecondaryAddress())
                .RuleFor(p => p.CodigoCidade, f => f.Address.CityPrefix())
                .RuleFor(p => p.Numero, f => f.Random.Number(10000).ToString())
                .RuleFor(p => p.Telefone, f => f.Phone.PhoneNumber())
                .RuleFor(p => p.Estado, f => f.Address.StateAbbr());

            cmd.Proprietario = fakerPro.Generate();

            var fakerV = new Faker<VeiculoCommand>()
                .RuleFor(v => v.Tipo, f => f.Random.ArrayElement<string>(new string[] { "Bitrem", "Rodotrem", "Quinta roda", "Carreta Dolly", "bitrenz�o" }))
                .RuleFor(v => v.Placa, f => f.Random.Words())
                .RuleFor(v => v.Chassi, f => f.Company.Cnpj())
                .RuleFor(v => v.Rntrc, f => f.Random.Guid().ToString())
                .RuleFor(v => v.DataLicenciamento, f => f.Date.Between(DateTime.Today.AddYears(-1), DateTime.Today))
                .RuleFor(v => v.Cor, f => f.Random.ArrayElement<string>(new string[] { "preto", "branco", "azul", "amarelo", "Rosa", "vermelho" }))
                .RuleFor(v => v.Marca, f => f.Company.CompanyName())
                .RuleFor(v => v.Modelo, f => f.Company.CompanyName())
                .RuleFor(v => v.AnoFabricacao, f => f.Random.Int(1999, 2023))
                .RuleFor(v => v.AnoModelo, f => f.Random.Int(1999, 2023))
                .RuleFor(v => v.Estado, f => f.Address.StateAbbr())
                .RuleFor(v => v.CodigoCidade, f => f.Address.CitySuffix())
                .RuleFor(v => v.ImagemCrlv, f => f.Random.AlphaNumeric(20))
                .RuleFor(v => v.Renavam, f => f.Company.Cnpj());

            cmd.Veiculos = fakerV.Generate(3);
            return cmd;
        }
    }
}
