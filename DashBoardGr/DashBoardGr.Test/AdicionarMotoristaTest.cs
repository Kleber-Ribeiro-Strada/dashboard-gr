using Bogus;
using DashBoardGr.Domain.Application.Commands.AdicionarMotorista;
using Bogus.Extensions.Brazil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using System.Threading;
using Moq;
using DashBoardGr.Domain.Repository.Repositories.Interfaces;
using FluentAssertions;
using MediatR;
using FluentValidation;
using AutoMapper;
using DashBoardGr.Domain.Repository.Entities;
using FluentValidation.Results;

namespace DashBoardGr.Test
{
    public class AdicionarMotoristaTest
    {
        private readonly Mock<IMotoristaRepository> _motoristaRepositoryMock;
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<IMapper> _mapper;
        public AdicionarMotoristaTest()
        {
            _motoristaRepositoryMock = new();
            _mediatorMock = new();
            _mapper = new();
        }

        [Fact]
        public async Task Handle_DeveRetornarCommandResponseComId_QuandoValido()
        {
            // Arrange
            var request = GerarMotoristaPreenchido();

            var validatorMock = new Mock<IValidator<AdicionarMotoristaCommand>>();
            validatorMock.Setup(v => v.ValidateAsync(request, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new FluentValidation.Results.ValidationResult()); // Simule uma validação bem-sucedida

            var mapperMock = new Mock<IMapper>();
            var motoristaRepositoryMock = new Mock<IMotoristaRepository>();
            var mediatorMock = new Mock<IMediator>();

            var handler = new AdicionarMotoristaCommandHandler(
                motoristaRepositoryMock.Object,
                mediatorMock.Object,
                validatorMock.Object,
                mapperMock.Object);

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            response.Should().NotBeNull(); // Verifique se a resposta não é nula
            response.StatusCode.Should().Be(200); // Verifique se o código de status é 200 (ou o código desejado)
            response.Message.Should().Be("Motorista adicionado com sucesso."); // Verifique a mensagem da resposta
            response.Data.Should().BeOfType<int>(); // Verifique se a propriedade Data é um inteiro (ID)

            // Você também pode verificar outras expectativas com base na lógica do método Handle
            motoristaRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Motorista>(), It.IsAny<Cnh>()), Times.Once);
            mediatorMock.Verify(m => m.Publish(It.IsAny<MotoristaAdicionadoEvent>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_DeveRetornarCommandResponseComStatusCode400_QuandoInvalido()
        {
            // Arrange
            var request = GerarMotoristaPreenchido();
            request.Nome = string.Empty;

            var validationResult = new FluentValidation.Results.ValidationResult();
            validationResult.Errors.Add(new ValidationFailure("Nome", "O campo Nome é obrigatório."));

            var validatorMock = new Mock<IValidator<AdicionarMotoristaCommand>>();
            validatorMock.Setup(v => v.ValidateAsync(request, It.IsAny<CancellationToken>()))
                .ReturnsAsync(validationResult); // Simule uma validação malsucedida

            var mapperMock = new Mock<IMapper>();
            var motoristaRepositoryMock = new Mock<IMotoristaRepository>();
            var mediatorMock = new Mock<IMediator>();

            var handler = new AdicionarMotoristaCommandHandler(
                motoristaRepositoryMock.Object,
                mediatorMock.Object,
                validatorMock.Object,
                mapperMock.Object);


            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            response.Should().NotBeNull(); // Verifique se a resposta não é nula
            response.IsSuccessStatusCode.Should().BeFalse(); // Verifique se o código de status é 400
            response.Message.Should().Be("Requisição inválida"); // Verifique a mensagem de erro da resposta
            response.Data.Should().NotBeNull(); // Verifique se há erros na resposta
        }

        [Fact]
        public async Task Adicioanr_Motorista_Numero_Nao_Preenchido_Faliure()
        {
            //Arrange
            var command = GerarMotoristaPreenchido();
            command.Numero = "";

            //Act
            var validator = new MotoristaValidator(_motoristaRepositoryMock.Object);
            var result = await validator.ValidateAsync(command);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle(e => e.ErrorMessage == "Campo Número Residência é obrigatório");
        }

        [Fact]
        public async Task Adicioanr_Motorista_Cep_Nao_Preenchido_Faliure()
        {
            //Arrange
            var command = GerarMotoristaPreenchido();
            command.Cep = "";

            //Act
            var validator = new MotoristaValidator(_motoristaRepositoryMock.Object);
            var result = await validator.ValidateAsync(command);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle(e => e.ErrorMessage == "Campo CEP é obrigatório");
        }

        [Fact]
        public async Task Adicioanr_Motorista_Nome_Email_Invalido_Faliure()
        {
            //Arrange
            var command = GerarMotoristaPreenchido();
            command.Email = "teste";

            //Act
            var validator = new MotoristaValidator(_motoristaRepositoryMock.Object);
            var result = await validator.ValidateAsync(command);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle(e => e.ErrorMessage == "O endereço de e-mail não é válido.");
        }

        [Fact]
        public async Task Adicioanr_Motorista_Nome_Email_nao_Preenchido_Faliure()
        {
            //Arrange
            var command = GerarMotoristaPreenchido();
            command.Email = string.Empty;

            //Act
            var validator = new MotoristaValidator(_motoristaRepositoryMock.Object);
            var result = await validator.ValidateAsync(command);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle(e => e.ErrorMessage == "Campo E-mail é obrigatório");
        }

        [Fact]
        public async Task Adicioanr_Motorista_Nome_Mae_Nao_Preenchido_Faliure()
        {
            //Arrange
            var command = GerarMotoristaPreenchido();
            command.NomeMae = string.Empty;

            //Act
            var validator = new MotoristaValidator(_motoristaRepositoryMock.Object);
            var result = await validator.ValidateAsync(command);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle(e => e.ErrorMessage == "Campo Nome da Mãe é obrigatório");
        }

        [Fact]
        public async Task Adicioanr_Motorista_Cpf_Invalido_Faliure()
        {
            //Arrange
            var command = GerarMotoristaPreenchido();
            command.Cpf = "12345678900";

            //Act
            var validator = new MotoristaValidator(_motoristaRepositoryMock.Object);
            var result = await validator.ValidateAsync(command);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle(e => e.ErrorMessage == "Campo CPF inválido");
        }

        [Fact]
        public async Task Adicioanr_Motorista_Cpf_Vazio_Faliure()
        {
            //Arrange
            var command = GerarMotoristaPreenchido();
            command.Cpf = string.Empty;

            //Act
            var validator = new MotoristaValidator(_motoristaRepositoryMock.Object);
            var result = await validator.ValidateAsync(command);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle(e => e.ErrorMessage == "Campo CPF é obrigatório");
        }

        [Fact]
        public async Task Adicioanr_Motorista_Menores_18_Faliure()
        {
            //Arrange
            var command = GerarMotoristaPreenchido();
            command.DataNascimento = DateTime.Now.AddYears(17);

            //Act
            var validator = new MotoristaValidator(_motoristaRepositoryMock.Object);
            var result = await validator.ValidateAsync(command);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle(e => e.ErrorMessage == "Só é permitiro motoristas maiores de 18 anos");
        }

        [Fact]
        public async Task Adicioanr_Motorista_genero_Nao_Preenchido_Faliure()
        {
            //Arrange
            var command = GerarMotoristaPreenchido();
            command.Genero = string.Empty;

            //Act
            var validator = new MotoristaValidator(_motoristaRepositoryMock.Object);
            var result = await validator.ValidateAsync(command);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle(e => e.ErrorMessage == "Campo gênero tem que ser Masculino ou Feminino (M ou F)");
        }

        [Fact]
        public async Task Adicioanr_Motorista_genero_invalido_Faliure()
        {
            //Arrange
            var command = GerarMotoristaPreenchido();
            command.Genero = "X";

            //Act
            var validator = new MotoristaValidator(_motoristaRepositoryMock.Object);
            var result = await validator.ValidateAsync(command);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle(e => e.ErrorMessage == "Campo gênero tem que ser Masculino ou Feminino (M ou F)");
        }

        [Fact]
        public async Task Adicioanr_Motorista_sem_nome_Faliure()
        {
            //Arrange
            var command = GerarMotoristaPreenchido();
            command.Nome = string.Empty;

            //Act
            var validator = new MotoristaValidator(_motoristaRepositoryMock.Object);
            var result = await validator.ValidateAsync(command);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle(e => e.ErrorMessage == "Campo Nome é obrigatório");
        }

        [Fact]
        public async Task Adicionar_motorista_success()
        {
            //Arrange
            var command = GerarMotoristaPreenchido();

            //Act
            var validator = new MotoristaValidator(_motoristaRepositoryMock.Object);
            var result = await validator.ValidateAsync(command);

            //Assert
            result.IsValid.Should().BeTrue();
            Assert.True(result.IsValid);

        }


        private AdicionarMotoristaCommand GerarMotoristaPreenchido()
        {
            var addMotoristaFake = new Faker<AdicionarMotoristaCommand>("pt_BR")
                    .RuleFor(m => m.Nome, f => f.Person.FullName)
                    .RuleFor(m => m.Genero, f => f.Person.Gender.ToString().Substring(0, 1))
                    .RuleFor(m => m.DataNascimento, f => f.Date.Between(DateTime.Today.AddYears(-80), DateTime.Today.AddYears(-19)))
                    .RuleFor(m => m.Cpf, f => f.Person.Cpf())
                    .RuleFor(m => m.Rg, f => f.Person.Cpf())
                    .RuleFor(m => m.EstadoEmissao, f => f.Address.StateAbbr())
                    .RuleFor(m => m.DataEmissao, f => f.Date.Between(DateTime.Today.AddYears(-10), DateTime.Today))
                    .RuleFor(m => m.NomeMae, f => f.Person.FullName)
                    .RuleFor(m => m.NomePai, f => f.Person.FullName)
                    .RuleFor(m => m.Telefone, f => f.Phone.PhoneNumber())
                    .RuleFor(m => m.Email, f => f.Person.Email)
                    .RuleFor(m => m.NomeReferencia, f => f.Person.FullName)
                    .RuleFor(m => m.TelefoneReferencia, f => f.Phone.PhoneNumber())
                    .RuleFor(m => m.Cep, f => f.Address.ZipCode())
                    .RuleFor(m => m.Numero, f => f.Random.Number(0, 10000).ToString())
                    .RuleFor(m => m.Rua, f => f.Address.StreetAddress())
                    .RuleFor(m => m.Bairro, f => f.Address.StreetAddress())
                    .RuleFor(m => m.Estado, f => f.Address.StateAbbr())
                    .RuleFor(m => m.CodigoCidade, f => f.Address.City())
                    .RuleFor(m => m.Complemento, f => f.Address.SecondaryAddress())
                    .RuleFor(m => m.NomeCidade, f => f.Address.StreetAddress());


            var cnhFaker = new Faker<AdicionarCnhMotoristaCommand>("pt_BR")
                .RuleFor(m => m.Numero, f => f.Person.Cpf())
                .RuleFor(m => m.EstadoEmissao, f => f.Address.StateAbbr())
                .RuleFor(m => m.Categoria, f => f.Random.ArrayElement<string>(new string[] { "A", "B", "C", "D" }))
                .RuleFor(m => m.DataPrimeiraHabilitacao, f => f.Date.Past(10))
                .RuleFor(m => m.Imagem, f => f.Random.AlphaNumeric(20));

            //Arrange
            var command = addMotoristaFake.Generate();
            command.Cnh = cnhFaker.Generate();

            return command;
        }
    }
}
