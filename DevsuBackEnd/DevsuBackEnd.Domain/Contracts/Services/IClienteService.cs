using DevsuBackEnd.Domain.Models;

namespace DevsuBackEnd.Domain.Contracts.Services;

public interface IClienteService
{
    Task<IEnumerable<ClienteModel>> GetAllAsync(string? search);
    Task<ClienteModel?> GetByIdAsync(int id);
    Task<ClienteModel> AddAsync(ClienteModel cliente);
    Task<ClienteModel?> UpdateAsync(int id, ClienteModel cliente);
    Task<bool> DeleteAsync(int id);
}