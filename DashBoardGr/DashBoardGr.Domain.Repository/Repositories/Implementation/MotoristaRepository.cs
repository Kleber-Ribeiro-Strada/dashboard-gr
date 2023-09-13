using DashBoardGr.Domain.Repository.Entities;
using DashBoardGr.Domain.Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Repository.Repositories.Implementation
{
    public class MotoristaRepository : IMotoristaRepository
    {

        private readonly AppDbContext _appDbContext;

        public MotoristaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Motorista motorista)
        {
            await _appDbContext.AddAsync(motorista);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
