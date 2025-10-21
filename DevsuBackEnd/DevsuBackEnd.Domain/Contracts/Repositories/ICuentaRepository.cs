using DevsuBackEnd.Domain.Models;

namespace DevsuBackEnd.Domain.Contracts.Repositories;

public interface ICuentaRepository
{
    Task<IEnumerable<CuentaModel>> GetAllAsync(string? search);
    Task<CuentaModel?> GetByIdAsync(int id);
    Task<IEnumerable<TipoCuentaModel>> GetAllTiposCuenta();
    Task<CuentaModel> AddAsync(CuentaModel model);
    Task<CuentaModel?> UpdateAsync(int id, CuentaModel model);
    Task<bool> DeleteAsync(int id);
}