using DevsuBackEnd.Domain.Contracts.Repositories;
using DevsuBackEnd.Domain.Contracts.Services;
using DevsuBackEnd.Domain.Exceptions;
using DevsuBackEnd.Domain.Models;
using DevsuBackEnd.Domain.Utils;

namespace DevsuBackEnd.Domain.Services;

public class MovimientoService : IMovimientoService
{
    private IMovimientoRepository _repository;
    private ICuentaRepository _cuentaRepository;

    public MovimientoService(IMovimientoRepository repository, ICuentaRepository cuentaRepository)
    {
        _repository = repository;
        _cuentaRepository = cuentaRepository;
    }

    public async Task<IEnumerable<MovimientoModel>> GetAllAsync(string? search)
    {
        return await _repository.GetAllAsync(search);
    }

    public async Task<IEnumerable<TipoMovimientoModel>> GetAllTiposMovimiento()
    {
        return await _repository.GetAllTiposMovimiento();
    }

    public async Task<MovimientoModel> AddAsync(MovimientoModel model)
    {
        if (model.FechaMovimiento == default)
            throw new ArgumentException("La fecha del movimiento es obligatoria.");
        
        var cuenta = await _cuentaRepository.GetByIdAsync(model.CuentaId);
        var movimientosHoy = await _repository.GetMovimientosPorCuentaYFecha(model.CuentaId, model.FechaMovimiento.Date);
        
        if (model.TipoMovimientoId == (int)Constants.TipoMovimiento.Debito)
        {
            var saldoDisponible = movimientosHoy.LastOrDefault()?.Saldo ?? cuenta.SaldoInicial;
            
            if (saldoDisponible < model.Valor)
                throw new ValidationException("Saldo no disponible");

            var totalDebitoHoy = movimientosHoy
                .Where(m => m.TipoMovimientoId == (int)Constants.TipoMovimiento.Debito)
                .Sum(m => m.Valor);

            if (totalDebitoHoy + model.Valor > 1000)
                throw new ValidationException("Cupo diario excedido");
        }
        
        var saldoAnterior = movimientosHoy.LastOrDefault()?.Saldo ?? cuenta.SaldoInicial;
        model.Saldo = model.TipoMovimientoId == (int)Constants.TipoMovimiento.Credito
            ? saldoAnterior + model.Valor
            : saldoAnterior - model.Valor;
        
        return await _repository.AddAsync(model);
    }
}