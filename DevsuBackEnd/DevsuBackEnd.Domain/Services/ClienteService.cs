using DevsuBackEnd.Domain.Contracts.Repositories;
using DevsuBackEnd.Domain.Contracts.Services;
using DevsuBackEnd.Domain.Exceptions;
using DevsuBackEnd.Domain.Models;

namespace DevsuBackEnd.Domain.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _repository;

    public ClienteService(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ClienteModel>> GetAllAsync(string? search)
    {
        return await _repository.GetAllAsync(search);
    }
    
    public async Task<ClienteModel?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<ClienteModel> AddAsync(ClienteModel cliente)
    {
        if (string.IsNullOrWhiteSpace(cliente.Nombre))
            throw new ValidationException("El nombre del cliente es obligatorio.");

        if (string.IsNullOrWhiteSpace(cliente.Identificacion))
            throw new ValidationException("La identificación es obligatoria.");

        if (string.IsNullOrWhiteSpace(cliente.Contrasena))
            throw new ValidationException("La contraseña es obligatoria.");
        
        return await _repository.AddAsync(cliente);
    }
    
    public async Task<ClienteModel?> UpdateAsync(int id, ClienteModel cliente)
    {
        return await _repository.UpdateAsync(id, cliente);
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}