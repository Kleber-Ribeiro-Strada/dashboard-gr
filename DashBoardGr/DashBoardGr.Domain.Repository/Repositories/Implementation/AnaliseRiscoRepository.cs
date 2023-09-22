using DashBoardGr.Domain.Repository.Dtos;
using DashBoardGr.Domain.Repository.Entities;
using DashBoardGr.Domain.Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Repository.Repositories.Implementation
{
    public class AnaliseRiscoRepository : IAnaliseRiscoRepository
    {
        private readonly AppDbContext _appDbContext;
        public AnaliseRiscoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<IEnumerable<AnaliseRisco>> BuscarAnalisesAnalisesRisco(DateTime? dataSolicitacaoDe, DateTime? dataSolicitacaoAte, string? cpf, string? status)
        {
            var query = _appDbContext.AnaliseRisco.AsQueryable();
            if (dataSolicitacaoDe.HasValue)
            {
                query = query.Where(ar=>ar.DataSolicitacaoAnalise >= dataSolicitacaoDe.Value);
            }

            if (dataSolicitacaoAte.HasValue)
            {
                query = query.Where(ar=>ar.DataSolicitacaoAnalise <= dataSolicitacaoAte.Value.AddHours(26.9d));
            }

            if (!string.IsNullOrEmpty(cpf))
            {
                query = query.Where(ar => ar.Motorista.Cpf == cpf);
            }

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(ar => ar.Status == status);
            }

            return Task.FromResult(query.AsEnumerable());
        }



        public async Task SolicitarAnaliseRisco(AnaliseRisco analiseRisco, List<Veiculo> veiculos)
        {
            await _appDbContext.AddRangeAsync(analiseRisco);
            var analiseRiscoVeiculos = new List<AnaliseRiscoVeiculo>();

            veiculos.ForEach(v => analiseRiscoVeiculos.Add(new AnaliseRiscoVeiculo(analiseRisco.Id, v.Id)));

            await _appDbContext.AddRangeAsync(analiseRiscoVeiculos);
            await _appDbContext.SaveChangesAsync();
        }

        public Task<GraficoGeralDto> BuscarGraficoPorSemana(DateTime? dataSolicitacaoDe, DateTime? dataSolicitacaoAte)
        {
            var analisesFiltradas = _appDbContext.AnaliseRisco
             .Where(a => a.Status == "Pendente" || a.Status == "Reprovado")
             .ToList(); // Carrega os dados do banco de dados em memória

            var analises = analisesFiltradas
                .GroupBy(a => new
                {
                    Semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(a.DataSolicitacaoAnalise, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday),
                    Status = a.Status
                })
                .Select(g => new Teste
                {
                    Parameter = g.Key.Semana,
                    Status = g.Key.Status,
                    Quantidade = g.Count()
                })
                .OrderBy(g => g.Parameter);

            GraficoGeralDto result = new();
            result.Labels = analises.Select(a => a.Parameter.ToString()).ToList();
            result.DastaSet.Add(new GraficoGeralDto.DadosGraficosDto
            {
                Data = analises.Where(x=>x.Status=="Pendente").Select(x=>x.Quantidade).ToList(),
                Label = "Pendente" //mudar para reprovado
            });

            result.DastaSet.Add(new GraficoGeralDto.DadosGraficosDto
            {
                Data = analises.Where(x => x.Status == "Aprovado").Select(x => x.Quantidade).ToList(),
                Label = "Aprovado" //mudar para reprovado
            });


            return Task.FromResult(result);
        }

        public Task<GraficoGeralDto> BuscarGraficoPorDia(DateTime? dataSolicitacaoDe, DateTime? dataSolicitacaoAte)
        {
            var analisesFiltradas = _appDbContext.AnaliseRisco
             .Where(a => a.Status == "Pendente" || a.Status == "Reprovado")
             .ToList(); // Carrega os dados do banco de dados em memória

            var analises = analisesFiltradas
                .GroupBy(a => new
                {
                    Status = a.Status
                })
                .Select(g => new Teste
                {
                    Status = g.Key.Status,
                    Quantidade = g.Count()
                })
                .OrderBy(g => g.Parameter);

            GraficoGeralDto result = new();
            result.Labels = analises.Select(a => a.Parameter.ToString()).ToList();
            result.DastaSet.Add(new GraficoGeralDto.DadosGraficosDto
            {
                Data = analises.Where(x=>x.Status=="Pendente").Select(x=>x.Quantidade).ToList(),
                Label = "Pendente" //mudar para reprovado
            });

            result.DastaSet.Add(new GraficoGeralDto.DadosGraficosDto
            {
                Data = analises.Where(x => x.Status == "Aprovado").Select(x => x.Quantidade).ToList(),
                Label = "Aprovado" //mudar para reprovado
            });


            return Task.FromResult(result);
        }

        public Task<GraficoGeralDto> BuscarGraficoPorHora(DateTime? dataSolicitacaoDe, DateTime? dataSolicitacaoAte)
        {

            var analisesFiltradas = _appDbContext.AnaliseRisco
             .Where(a => a.Status == "Pendente" || a.Status == "Reprovado")
             .ToList(); // Carrega os dados do banco de dados em memória

            var analises = analisesFiltradas
                .GroupBy(a => new
                {
                    Hora = CultureInfo.CurrentCulture.Calendar.GetHour(a.DataSolicitacaoAnalise),
                    Status = a.Status
                })
                .Select(g => new Teste
                {
                    Parameter = g.Key.Hora,
                    Status = g.Key.Status,
                    Quantidade = g.Count()
                })
                .OrderBy(g => g.Parameter);

            GraficoGeralDto result = new();
            result.Labels = analises.Select(a => a.Parameter.ToString()).ToList();
            result.DastaSet.Add(new GraficoGeralDto.DadosGraficosDto
            {
                Data = analises.Where(x => x.Status == "Pendente").Select(x => x.Quantidade).ToList(),
                Label = "Pendente" //mudar para reprovado
            });

            result.DastaSet.Add(new GraficoGeralDto.DadosGraficosDto
            {
                Data = analises.Where(x => x.Status == "Aprovado").Select(x => x.Quantidade).ToList(),
                Label = "Aprovado" //mudar para reprovado
            });

            return Task.FromResult(result);
        }
    }
}
