namespace DevsuBackEnd.Domain.Models;

public class MovimientoModel
{
    public int MovimientoId { get; set; }
    public int CuentaId { get; set; }
    public string NumeroCuenta { get; set; } = string.Empty;
    public string TipoCuenta { get; set; } = string.Empty;
    public decimal SaldoInicial { get; set; }
    public int TipoMovimientoId { get; set; }
    public string TipoMovimiento { get; set; } = string.Empty;
    public bool TipoMovimientoFactor { get; set; }
    public DateTime FechaMovimiento { get; set; }
    public DateTime FechaCreacion { get; set; }
    public decimal Valor { get; set; }
    public decimal Saldo { get; set; }
    public bool? Estado { get; set; }
}