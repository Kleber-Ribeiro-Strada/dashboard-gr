using DashBoardGr.Domain.Repository.Dtos;
using DashBoardGr.Domain.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Repository.Repositories.Interfaces
{
    public interface IAnaliseRiscoRepository
    {
        Task<AnaliseRisco> SolicitarAnaliseRisco(AnaliseRisco analiseRisco, List<Veiculo> veiculos);

        Task<IEnumerable<AnaliseRisco>> BuscarAnalisesAnalisesRisco(
            DateTime? dataSolicitacaoDe,
            DateTime? dataSolicitacaoAte,
            string? cpf,
            string? status);

        Task<AnaliseRisco?> BuscarAnaliseRisco(Guid Id);

        Task<GraficoGeralDto> BuscarGraficoPorSemana(DateTime? dataSolicitacaoDe, DateTime? dataSolicitacaoAte);
        Task<GraficoGeralDto> BuscarGraficoPorPeriodo(DateTime? dataSolicitacaoDe, DateTime? dataSolicitacaoAte);
        Task<GraficoGeralDto> BuscarGraficoPorHora(DateTime? dataSolicitacaoDe, DateTime? dataSolicitacaoAte);
        Task Avaliar(Guid id, string status, string motivo, string observação);
    }
}
