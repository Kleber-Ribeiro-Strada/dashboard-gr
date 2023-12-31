﻿using DashBoardGr.Domain.Repository.Dtos;
using DashBoardGr.Domain.Repository.Entities;
using DashBoardGr.Domain.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public Task<IEnumerable<AnaliseRisco>> BuscarAnalisesAnalisesRisco(
            DateTime? dataSolicitacaoDe,
            DateTime? dataSolicitacaoAte,
            string? cpf,
            string? status)
        {
            var query = _appDbContext.AnaliseRisco.AsQueryable();
            if (dataSolicitacaoDe.HasValue)
            {
                query = query.Where(ar => ar.DataSolicitacaoAnalise >= dataSolicitacaoDe.Value);
            }

            if (dataSolicitacaoAte.HasValue)
            {
                query = query.Where(ar => ar.DataSolicitacaoAnalise <= dataSolicitacaoAte.Value.AddHours(26.9d));
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

        public async Task<AnaliseRisco> SolicitarAnaliseRisco(AnaliseRisco analiseRisco, List<Veiculo> veiculos)
        {
            await _appDbContext.AddAsync(analiseRisco);
            var analiseRiscoVeiculos = new List<AnaliseRiscoVeiculo>();

            veiculos.ForEach(v => analiseRiscoVeiculos.Add(new AnaliseRiscoVeiculo(analiseRisco.Id, v.Id)));

            await _appDbContext.AddRangeAsync(analiseRiscoVeiculos);
            await _appDbContext.SaveChangesAsync();

            return analiseRisco;
        }

        public Task<GraficoGeralDto> BuscarGraficoPorSemana(DateTime? dataSolicitacaoDe, DateTime? dataSolicitacaoAte)
        {
            var analisesFiltradas = _appDbContext.AnaliseRisco.AsQueryable();
            if (dataSolicitacaoDe != null)
                analisesFiltradas = analisesFiltradas.Where(a => a.DataSolicitacaoAnalise >= dataSolicitacaoDe);

            if (dataSolicitacaoAte != null)
                analisesFiltradas = analisesFiltradas.Where(a => a.DataSolicitacaoAnalise <= dataSolicitacaoAte.Value.AddHours(23.9d));

            var analises = analisesFiltradas.AsEnumerable()
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
            result.Labels = analises.Select(a => $"Semana: {a.Parameter.ToString()}").ToList();
            result.Datasets.Add(new GraficoGeralDto.DadosGraficosDto
            {
                Data = analises.Where(x => x.Status == "Pendente").Select(x => x.Quantidade).ToList(),
                Label = "Pendente"
            });

            result.Datasets.Add(new GraficoGeralDto.DadosGraficosDto
            {
                Data = analises.Where(x => x.Status == "Aprovado").Select(x => x.Quantidade).ToList(),
                Label = "Aprovado"
            });

            result.Datasets.Add(new GraficoGeralDto.DadosGraficosDto
            {
                Data = analises.Where(x => x.Status == "Reprovado").Select(x => x.Quantidade).ToList(),
                Label = "Reprovado"
            });


            foreach (var item in result.Datasets)
            {
                if (item.Data.Count() == 0)
                {
                    item.Data.Add(0);
                }
            }

            return Task.FromResult(result);
        }

        public Task<GraficoGeralDto> BuscarGraficoPorPeriodo(DateTime? dataSolicitacaoDe, DateTime? dataSolicitacaoAte)
        {
            var analisesFiltradas = _appDbContext.AnaliseRisco.AsQueryable();
            if (dataSolicitacaoDe != null)
                analisesFiltradas = analisesFiltradas.Where(a => a.DataSolicitacaoAnalise >= dataSolicitacaoDe);

            if (dataSolicitacaoAte != null)
                analisesFiltradas = analisesFiltradas.Where(a => a.DataSolicitacaoAnalise <= dataSolicitacaoAte.Value.AddHours(23.9d));

            var analises = analisesFiltradas.AsEnumerable()
                .GroupBy(a => new
                {
                    Status = a.Status
                })
                .Select(g => new Teste
                {
                    Status = g.Key.Status,
                    Quantidade = (g.Count() * 100 / analisesFiltradas.Count()),

                })
                .OrderBy(g => g.Parameter);

            GraficoGeralDto result = new();
            result.Labels = analises.Select(a => a.Status.ToString()).ToList();
            result.Datasets.Add(new GraficoGeralDto.DadosGraficosDto
            {
                Data = analises.Select(x => x.Quantidade).ToList(),  
            });

           

            return Task.FromResult(result);
        }

        public Task<GraficoGeralDto> BuscarGraficoPorHora(DateTime? dataSolicitacaoDe, DateTime? dataSolicitacaoAte)
        {

            var analisesFiltradas = _appDbContext.AnaliseRisco.AsQueryable();
            if (dataSolicitacaoDe != null)
                analisesFiltradas = analisesFiltradas.Where(a => a.DataSolicitacaoAnalise >= dataSolicitacaoDe);

            if (dataSolicitacaoAte != null)
                analisesFiltradas = analisesFiltradas.Where(a => a.DataSolicitacaoAnalise <= dataSolicitacaoAte.Value.AddHours(23.9d));

            var analises = analisesFiltradas.AsEnumerable()
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
            result.Labels = analises.Select(a => $"{a.Parameter}:00").ToList();
            result.Datasets.Add(new GraficoGeralDto.DadosGraficosDto
            {
                Data = analises.Where(x => x.Status == "Pendente").Select(x => x.Quantidade).ToList(),
                Label = "Pendente"
            });

            result.Datasets.Add(new GraficoGeralDto.DadosGraficosDto
            {
                Data = analises.Where(x => x.Status == "Aprovado").Select(x => x.Quantidade).ToList(),
                Label = "Aprovado"
            });

            result.Datasets.Add(new GraficoGeralDto.DadosGraficosDto
            {
                Data = analises.Where(x => x.Status == "Reprovado").Select(x => x.Quantidade).ToList(),
                Label = "Reprovado"
            });

            foreach (var item in result.Datasets)
            {
                if (item.Data.Count() == 0)
                {
                    item.Data.Add(0);
                }
            }

            return Task.FromResult(result);
        }

        public Task<AnaliseRisco?> BuscarAnaliseRisco(Guid Id)
        {
            return _appDbContext.AnaliseRisco.SingleOrDefaultAsync(x => x.Id == Id);
        }

        public async Task Avaliar(Guid id, string status, string motivo, string observacao)
        {
            try
            {


                var analise = _appDbContext.AnaliseRisco.SingleOrDefault(an => an.Id == id);
                if (analise != null)
                {
                    analise.Avaliar(status, motivo, observacao);
                    _appDbContext.Update(analise);
                    await _appDbContext.SaveChangesAsync();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
