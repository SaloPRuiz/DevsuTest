using DevsuBackEnd.Domain.Contracts.Services;
using DevsuBackEnd.Domain.Models;

namespace DevsuBackEnd.Domain.Services;

public class MovimientoService : IMovimientoService
{
    public async Task<IEnumerable<MovimientoModel>> GetAllAsync(string? search)
    {
        throw new NotImplementedException();
    }

    public async Task<MovimientoModel?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<MovimientoModel> AddAsync(MovimientoModel model)
    {
        throw new NotImplementedException();
    }

    public async Task<MovimientoModel?> UpdateAsync(int id, MovimientoModel model)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}