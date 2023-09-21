using DashBoardGr.Domain.Repository.Entities;

namespace DashBoardGr.Domain.Repository.Repositories.Interfaces
{
    public interface IMotoristaRepository
    {
        Task AddAsync(Motorista motorista, Cnh cnh);

        Task AddVeiculo(Proprietario proprietario, List<Veiculo> veiculo);
        
        Task<Motorista> Get(Guid id);

        bool MotoristaExistente(string cpf);

        Task<IEnumerable<Motorista>> GetAll();
    }
}
