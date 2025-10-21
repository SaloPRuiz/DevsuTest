using DevsuBackEnd.Domain.Models;

namespace DevsuBackEnd.Domain.Contracts;

public interface IClienteRepository
{
    Task<IEnumerable<ClienteModel>> GetAllAsync();
    Task<ClienteModel?> GetByIdAsync(int id);
    Task<ClienteModel> AddAsync(ClienteModel model);
    Task<bool> ExisteIdentificacionAsync(string identificacion);
    Task<ClienteModel?> UpdateAsync(int id, ClienteModel model);
    Task<bool> DeleteAsync(int id);
}