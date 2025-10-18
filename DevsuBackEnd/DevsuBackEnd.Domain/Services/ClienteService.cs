using DevsuBackEnd.Domain.Contracts;
using DevsuBackEnd.Domain.Models;

namespace DevsuBackEnd.Domain.Services;

public class ClienteService
{
    private readonly IClienteRepository _repository;

    public ClienteService(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ClienteModel>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<ClienteModel> AddAsync(ClienteModel cliente)
    {
        return await _repository.AddAsync(cliente);
    }
}