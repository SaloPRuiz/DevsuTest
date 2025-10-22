using DevsuBackEnd.Domain.Models;

namespace DevsuBackEnd.Domain.Contracts.Repositories;

public interface IMovimientoRepository
{
    Task<IEnumerable<MovimientoModel>> GetAllAsync(string? search);
    Task<IEnumerable<TipoMovimientoModel>> GetAllTiposMovimiento();
    Task<List<MovimientoModel>> GetMovimientosPorCuentaYFecha(int cuentaId, DateTime fecha);
    Task<MovimientoModel?> GetByIdAsync(int id);
    Task<MovimientoModel> AddAsync(MovimientoModel model);
    Task<MovimientoModel?> UpdateAsync(int id, MovimientoModel model);
    Task<bool> DeleteAsync(int id);
}