using DevsuBackEnd.Domain.Contracts;
using DevsuBackEnd.Domain.Models;

namespace DevsuBackEnd.Infra.Repositories;

public class ClienteRepository : IClienteRepository
{
    public async Task<IEnumerable<ClienteModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<ClienteModel> AddAsync(ClienteModel cliente)
    {
        throw new NotImplementedException();
    }
}