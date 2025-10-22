using DevsuBackEnd.Domain.Contracts.Repositories;
using DevsuBackEnd.Domain.Models;
using DevsuBackEnd.Infra.Persistence.Context;
using DevsuBackEnd.Infra.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevsuBackEnd.Infra.Repositories;

public class MovimientoRepository : IMovimientoRepository
{
    private readonly AppDbContext _context;

    public MovimientoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MovimientoModel>> GetAllAsync(string? search)
    {
        var query = _context.Movimientos
            .Where(x => x.Estado == true)
            .AsQueryable();
        
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(c =>
                c.Cuenta.NumeroCuenta.Contains(search) ||
                c.Cuenta.SaldoInicial.ToString().Contains(search) ||
                (c.Cuenta.TipoCuenta.Descripcion != null && c.Cuenta.TipoCuenta.Descripcion.Contains(search)));
        }
        
        var movimientos = await query
            .OrderByDescending(c => c.MovimientoId)
            .Include(x => x.Cuenta).ThenInclude(cuenta => cuenta.TipoCuenta)
            .Include(x => x.TipoMovimiento)
            .ToListAsync();
        
        var resultado = movimientos.Select(c => new MovimientoModel
        {
            MovimientoId = c.MovimientoId,
            CuentaId = c.CuentaId,
            NumeroCuenta = c.Cuenta.NumeroCuenta,
            SaldoInicial = c.Cuenta.SaldoInicial,
            TipoCuenta = c.Cuenta.TipoCuenta.Nombre,
            TipoMovimientoId = c.TipoMovimientoId,
            TipoMovimiento = c.TipoMovimiento.Nombre,
            FechaMovimiento = c.FechaMovimiento,
            Valor = c.Valor,
            Saldo = c.Saldo,
            FechaCreacion = c.FechaCreacion,
            Estado = c.Estado
        });

        return resultado;
    }

    public async Task<IEnumerable<TipoMovimientoModel>> GetAllTiposMovimiento()
    {
        var query = await _context
            .TipoMovimientos
            .Select(x => new TipoMovimientoModel
            {
                TipoMovimientoId = x.TipoMovimientoId,
                Nombre = x.Nombre,
                EsPositivo = x.EsPositivo
            })
            .ToListAsync();
        
        return query;
    }

    public async Task<List<MovimientoModel>> GetMovimientosPorCuentaYFecha(int cuentaId, DateTime fecha)
    {
        return await _context.Movimientos
            .Where(m => m.CuentaId == cuentaId && m.FechaMovimiento.Date == fecha.Date)
            .OrderBy(m => m.FechaMovimiento)
            .ThenBy(m => m.FechaCreacion)
            .Select(x => new MovimientoModel
            {
                CuentaId = x.CuentaId,
                TipoMovimientoId = x.TipoMovimientoId,
                TipoMovimientoFactor = x.TipoMovimiento.EsPositivo,
                FechaMovimiento = x.FechaMovimiento,
                Saldo = x.Saldo,
                Valor = x.Valor
            })
            .ToListAsync();
    }

    public async Task<MovimientoModel?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<MovimientoModel> AddAsync(MovimientoModel model)
    {
        var entity = new Movimiento
        { 
            CuentaId = model.CuentaId,
            TipoMovimientoId = model.TipoMovimientoId,
            FechaMovimiento = model.FechaMovimiento,
            Saldo = model.Saldo,
            Valor = model.Valor,
        };

        _context.Movimientos.Add(entity);
        await _context.SaveChangesAsync();
 
        model.MovimientoId = entity.MovimientoId;

        return model;
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