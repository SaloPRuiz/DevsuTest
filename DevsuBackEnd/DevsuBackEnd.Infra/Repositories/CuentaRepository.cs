using DevsuBackEnd.Domain.Contracts.Repositories;
using DevsuBackEnd.Domain.Models;
using DevsuBackEnd.Infra.Persistence.Context;
using DevsuBackEnd.Infra.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevsuBackEnd.Infra.Repositories;

public class CuentaRepository : ICuentaRepository
{
    private readonly AppDbContext _context;
    
    public CuentaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CuentaModel>> GetAllAsync(string? search)
    {
        var query = _context.Cuenta
            .Where(x => x.Estado == true)
            .AsQueryable();
        
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(c =>
                c.NumeroCuenta.Contains(search) ||
                (c.TipoCuenta.Descripcion != null && c.TipoCuenta.Descripcion.Contains(search)));
        }
        
        var cuentas = await query
            .OrderByDescending(c => c.CuentaId)
            .Include(x => x.TipoCuenta)
            .ToListAsync();
        
        var resultado = cuentas.Select(c => new CuentaModel
        {
            CuentaId = c.CuentaId,
            NumeroCuenta = c.NumeroCuenta,
            TipoCuentaId = c.TipoCuentaId,
            TipoCuenta = c.TipoCuenta.Descripcion ?? string.Empty,
            SaldoInicial = c.SaldoInicial,
            Estado = c.Estado,
        });

        return resultado;
    }

    public async Task<CuentaModel?> GetByIdAsync(int id)
    {
        var entity = await _context.Cuenta
            .Include(x => x.TipoCuenta)
            .FirstOrDefaultAsync(x => x.CuentaId == id);

        if (entity == null) return null;

        return new CuentaModel
        {
            CuentaId = entity.CuentaId,
            NumeroCuenta = entity.NumeroCuenta,
            TipoCuentaId = entity.TipoCuentaId,
            TipoCuenta = entity.TipoCuenta.Descripcion ?? string.Empty,
            SaldoInicial = entity.SaldoInicial,
            Estado = entity.Estado,
        };
    }

    public async Task<IEnumerable<TipoCuentaModel>> GetAllTiposCuenta()
    {
        var query = await _context
            .TipoCuenta
            .Select(x => new TipoCuentaModel
            {
                TipoCuentaId = x.TipoCuentaId,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion
            })
            .ToListAsync();
        
        return query;
    }

    public async Task<CuentaModel> AddAsync(CuentaModel model)
    {
        var cuenta = new Cuenta
        {
            NumeroCuenta = model.NumeroCuenta,
            TipoCuentaId = model.TipoCuentaId,
            SaldoInicial = model.SaldoInicial
        };

        _context.Cuenta.Add(cuenta);
        await _context.SaveChangesAsync();
 
        model.CuentaId = cuenta.CuentaId;

        return model;
    }

    public async Task<CuentaModel?> UpdateAsync(int id, CuentaModel model)
    {
        var entity = await _context.Cuenta
            .FirstOrDefaultAsync(c => c.CuentaId == id);

        if (entity == null) return null;

        entity.NumeroCuenta = model.NumeroCuenta;
        entity.TipoCuentaId = model.TipoCuentaId;
        entity.SaldoInicial = model.SaldoInicial;
        entity.FechaModificacion = DateTime.Now;
        
        await _context.SaveChangesAsync();

        return model;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Cuenta
            .FirstOrDefaultAsync(c => c.CuentaId == id);

        if (entity == null) return false;
        
        entity.Estado = false;
        entity.FechaModificacion = DateTime.Now;

        await _context.SaveChangesAsync();
        return true;
    }
}