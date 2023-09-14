using DashBoardGr.Domain.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Repository.Repositories.Interfaces
{
    public interface IMotoristaRepository
    {
        Task AddAsync(Motorista motorista, Cnh cnh);
    }
}
