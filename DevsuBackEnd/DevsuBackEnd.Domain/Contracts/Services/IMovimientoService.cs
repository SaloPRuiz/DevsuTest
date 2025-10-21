using DevsuBackEnd.Domain.Models;

namespace DevsuBackEnd.Domain.Contracts.Services;

public interface IMovimientoService
{
    Task<IEnumerable<MovimientoModel>> GetAllAsync(string? search);
    Task<MovimientoModel?> GetByIdAsync(int id);
    Task<MovimientoModel> AddAsync(MovimientoModel model);
    Task<MovimientoModel?> UpdateAsync(int id, MovimientoModel model);
    Task<bool> DeleteAsync(int id);
}