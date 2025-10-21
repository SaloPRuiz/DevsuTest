using DevsuBackEnd.Domain.Models;

namespace DevsuBackEnd.Domain.Contracts.Repositories;

public interface IClienteRepository
{
    Task<IEnumerable<ClienteModel>> GetAllAsync(string? search);
    Task<ClienteModel?> GetByIdAsync(int id);
    Task<ClienteModel> AddAsync(ClienteModel model);
    Task<ClienteModel?> UpdateAsync(int id, ClienteModel model);
    Task<bool> DeleteAsync(int id);
}