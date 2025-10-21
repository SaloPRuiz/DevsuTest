using DevsuBackEnd.Domain.Contracts.Repositories;
using DevsuBackEnd.Domain.Models;

namespace DevsuBackEnd.Infra.Repositories;

public class MovimientoRepository : IMovimientoRepository
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