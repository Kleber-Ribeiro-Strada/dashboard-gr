using DashBoardGr.Domain.Repository.Entities;
using DashBoardGr.Domain.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DashBoardGr.Domain.Repository.Repositories.Implementation
{
    public class MotoristaRepository : IMotoristaRepository
    {

        private readonly AppDbContext _appDbContext;

        public MotoristaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Motorista motorista, Cnh cnh)
        {
            await _appDbContext.AddAsync(motorista);
            await _appDbContext.AddAsync(cnh);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task AddVeiculo(Proprietario proprietario, Veiculo veiculo)
        {
            await _appDbContext.AddAsync(proprietario);
            await _appDbContext.AddAsync(veiculo);
            await _appDbContext.SaveChangesAsync();
        }

        public Task<Motorista> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool MotoristaExistente(string cpf)
        {
            return _appDbContext.Motorista.Any(m => m.Cpf == cpf);
            
        }
    }
}
