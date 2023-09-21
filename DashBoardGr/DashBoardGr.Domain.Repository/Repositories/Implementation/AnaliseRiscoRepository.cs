using DashBoardGr.Domain.Repository.Entities;
using DashBoardGr.Domain.Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
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

        public async Task SolicitarAnaliseRisco(AnaliseRisco analiseRisco, List<Veiculo> veiculos)
        {
            await _appDbContext.AddRangeAsync(analiseRisco);
            var analiseRiscoVeiculos = new List<AnaliseRiscoVeiculo>();

            veiculos.ForEach(v => analiseRiscoVeiculos.Add(new AnaliseRiscoVeiculo(analiseRisco.Id, v.Id)));

            await _appDbContext.AddRangeAsync(analiseRiscoVeiculos);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
