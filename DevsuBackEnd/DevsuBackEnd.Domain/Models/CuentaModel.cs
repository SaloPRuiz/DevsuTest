namespace DevsuBackEnd.Domain.Models;

public class CuentaModel
{
    public int CuentaId { get; set; }
    public string NumeroCuenta { get; set; } = null!;
    public int TipoCuentaId { get; set; }
    public string TipoCuenta { get; set; } = null!;
    public decimal SaldoInicial { get; set; }
    public IEnumerable<MovimientoModel> Movimientos { get; set; } = null!;
    public bool? Estado { get; set; }
}