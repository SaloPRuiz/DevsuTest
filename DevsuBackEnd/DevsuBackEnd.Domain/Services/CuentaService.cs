using DevsuBackEnd.Domain.Contracts.Repositories;
using DevsuBackEnd.Domain.Contracts.Services;
using DevsuBackEnd.Domain.Exceptions;
using DevsuBackEnd.Domain.Models;

namespace DevsuBackEnd.Domain.Services;

public class CuentaService : ICuentaService
{
    private readonly ICuentaRepository _repository;

    public CuentaService(ICuentaRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CuentaModel>> GetAllAsync(string? search)
    {
        return await _repository.GetAllAsync(search);
    }

    public async Task<CuentaModel?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<TipoCuentaModel>> GetAllTiposCuenta()
    {
        return await _repository.GetAllTiposCuenta();
    }

    public async Task<CuentaModel> AddAsync(CuentaModel model)
    {
        if (string.IsNullOrWhiteSpace(model.NumeroCuenta))
            throw new ValidationException("El número de cuenta es obligatorio.");

        if (model.SaldoInicial <= 0)
            throw new ValidationException("El saldo inicial no puede ser menor a 0");
        
        return await _repository.AddAsync(model);
    }

    public async Task<CuentaModel?> UpdateAsync(int id, CuentaModel model)
    {
        return await _repository.UpdateAsync(id, model);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}