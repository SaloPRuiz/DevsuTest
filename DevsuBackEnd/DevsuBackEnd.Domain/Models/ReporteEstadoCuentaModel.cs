namespace DevsuBackEnd.Domain.Models;

public class ReporteEstadoCuentaModel
{
    public DateTime Fecha { get; set; }
    public string Cliente { get; set; } = string.Empty;
    public string NumeroCuenta { get; set; } = null!;
    public string TipoCuenta { get; set; } = null!;
    public decimal SaldoInicial { get; set; }
    public bool Estado { get; set; }
    public decimal Movimiento { get; set; }
    public decimal SaldoDisponible { get; set; }
}