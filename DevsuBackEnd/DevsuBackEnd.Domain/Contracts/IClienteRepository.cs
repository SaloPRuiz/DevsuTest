using DevsuBackEnd.Domain.Models;

namespace DevsuBackEnd.Domain.Contracts;

public interface IClienteRepository
{
    Task<IEnumerable<ClienteModel>> GetAllAsync();
    Task<ClienteModel> AddAsync(ClienteModel cliente);
}