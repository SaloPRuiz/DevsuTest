using DevsuBackEnd.Domain.Contracts.Repositories;
using DevsuBackEnd.Domain.Models;
using DevsuBackEnd.Domain.Utils;
using DevsuBackEnd.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace DevsuBackEnd.Infra.Repositories;

public class ReporteRepository : IReporteRepository
{
    private readonly AppDbContext _context;

    public ReporteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ReporteEstadoCuentaModel>> GetReportePorClienteAsync(int clienteId, DateTime fechaInicio, DateTime fechaFin)
    {
        var cuentas = await _context.Cuenta
            .Where(c => c.ClienteId == clienteId)
            .Select(c => new 
            { 
                c.CuentaId, 
                c.NumeroCuenta, 
                c.SaldoInicial, 
                c.Estado,
                TipoCuentaDescripcion = c.TipoCuenta.Nombre,
                ClienteNombre = c.Cliente.Persona.Nombre
            })
            .ToListAsync();
        
        var cuentaIds = cuentas.Select(c => c.CuentaId).ToList();
        
        var movimientos = await _context.Movimientos
            .Where(m => cuentaIds.Contains(m.CuentaId) &&
                        m.FechaMovimiento >= fechaInicio &&
                        m.FechaMovimiento <= fechaFin)
            .OrderBy(m => m.FechaMovimiento)
            .ThenBy(m => m.MovimientoId)
            .ToListAsync();
        
        var reporte = new List<ReporteEstadoCuentaModel>();
        
        foreach (var cuenta in cuentas)
        {
            var movimientosCuenta = movimientos
                .Where(m => m.CuentaId == cuenta.CuentaId)
                .ToList();
            
            foreach (var mov in movimientosCuenta)
            {
                var valorMovimiento = mov.TipoMovimientoId == (int)Constants.TipoMovimiento.Credito
                    ? mov.Valor
                    : -mov.Valor;

                reporte.Add(new ReporteEstadoCuentaModel
                {
                    Fecha = mov.FechaMovimiento,
                    Cliente = cuenta.ClienteNombre,
                    NumeroCuenta = cuenta.NumeroCuenta,
                    TipoCuenta = cuenta.TipoCuentaDescripcion,
                    SaldoInicial = cuenta.SaldoInicial,
                    Estado = cuenta.Estado.Value,
                    Movimiento = valorMovimiento,
                    SaldoDisponible = mov.Saldo
                });
            }
        }

        return reporte;
    }
}