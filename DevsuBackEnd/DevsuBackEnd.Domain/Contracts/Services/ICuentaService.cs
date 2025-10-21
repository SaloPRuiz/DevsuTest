using DevsuBackEnd.Domain.Models;

namespace DevsuBackEnd.Domain.Contracts.Services;

public interface ICuentaService
{
    Task<IEnumerable<CuentaModel>> GetAllAsync(string? search);
    Task<CuentaModel?> GetByIdAsync(int id);
    Task<CuentaModel> AddAsync(CuentaModel model);
    Task<CuentaModel?> UpdateAsync(int id, CuentaModel model);
    Task<bool> DeleteAsync(int id);
}