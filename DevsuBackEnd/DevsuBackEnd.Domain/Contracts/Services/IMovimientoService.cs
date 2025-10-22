using DevsuBackEnd.Domain.Models;

namespace DevsuBackEnd.Domain.Contracts.Services;

public interface IMovimientoService
{
    Task<IEnumerable<MovimientoModel>> GetAllAsync(string? search);
    Task<IEnumerable<TipoMovimientoModel>> GetAllTiposMovimiento();
    Task<MovimientoModel> AddAsync(MovimientoModel model);
}