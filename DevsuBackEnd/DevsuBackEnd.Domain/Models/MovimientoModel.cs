namespace DevsuBackEnd.Domain.Models;

public class MovimientoModel
{
    public int MovimientoId { get; set; }
    public int CuentaId { get; set; }
    public int TipoMovimientoId { get; set; }
    public string TipoMovimiento { get; set; } = null!;
    public DateTime FechaMovimiento { get; set; }
    public decimal Valor { get; set; }
    public decimal Saldo { get; set; }
    public bool? Estado { get; set; }
}