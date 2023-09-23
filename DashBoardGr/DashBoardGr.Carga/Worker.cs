using Bogus;
using Bogus.Extensions.Brazil;
using System.Net.Http;
using System;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using DashBoardGr.Carga.Models;
using System.Runtime.CompilerServices;
using static DashBoardGr.Carga.Models.SolicitarAnaliseCommand;

namespace DashBoardGr.Carga
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var addMotorista = new Faker<AddMotoristaCommand>("pt_BR")
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


                var cnh = new Faker<AddCnhMotoristaCommand>("pt_BR")
                    .RuleFor(m => m.Numero, f => f.Person.Cpf())
                    .RuleFor(m => m.EstadoEmissao, f => f.Address.StateAbbr())
                    .RuleFor(m => m.Categoria, f => f.Random.ArrayElement<string>(new string[] { "A", "B", "C", "D" }))
                    .RuleFor(m => m.DataPrimeiraHabilitacao, f => f.Date.Past(10))
                    .RuleFor(m => m.Imagem, f => f.Random.AlphaNumeric(20));
                var motoristas = addMotorista.Generate(20);
                foreach (var motorista in motoristas)
                {
                    motorista.Cnh = cnh.Generate();
                    var motoristaId = await AdicionarMotoristaHttp(motorista);

                    await AdicionarAnalise(motoristaId);
                    await Task.Delay(TimeSpan.FromMinutes(2));
                }

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(TimeSpan.FromMinutes(10));
            }



        }

        private async Task AdicionarAnalise(Guid motoristaId)
        {
            SolicitarAnaliseCommand cmd = new();
            cmd.MotoristaId = motoristaId;
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

            await SolicitarAnaliseHttp(cmd);

        }

        private async Task SolicitarAnaliseHttp(SolicitarAnaliseCommand analise)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                // URL para onde voc� deseja enviar o POST
                string url = "https://localhost:5223/api/analise/solicitar-analise";

                // O conte�do que voc� deseja enviar no corpo da solicita��o
                string jsonContent = JsonSerializer.Serialize(analise);

                // Crie o conte�do da solicita��o com base no JSON
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Fa�a a solicita��o POST
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                // Verifique se a solicita��o foi bem-sucedida
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Resposta do servidor:");
                    Console.WriteLine(responseContent);
                }
                else
                {
                    Console.WriteLine($"A solicita��o falhou com o status: {response.StatusCode}");
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent);
                }

            }
        }

        private async Task<Guid> AdicionarMotoristaHttp(AddMotoristaCommand motorista)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                // URL para onde voc� deseja enviar o POST
                string url = "https://localhost:5223/api/Motorista/adicionar";

                // O conte�do que voc� deseja enviar no corpo da solicita��o
                string jsonContent = JsonSerializer.Serialize(motorista);

                // Crie o conte�do da solicita��o com base no JSON
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Fa�a a solicita��o POST
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                // Verifique se a solicita��o foi bem-sucedida
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Resposta do servidor:");
                    Console.WriteLine(responseContent);
                    return Guid.Parse(JsonSerializer.Deserialize<Result>(responseContent).data);
                }
                else
                {
                    Console.WriteLine($"A solicita��o falhou com o status: {response.StatusCode}");
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent);
                }

                return Guid.Empty;
            }
        }
    }
}