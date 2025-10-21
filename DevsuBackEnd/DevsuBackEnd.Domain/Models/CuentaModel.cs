namespace DevsuBackEnd.Domain.Models;

public class CuentaModel
{
    public int CuentaId { get; set; }
    public int ClienteId { get; set; }
    public string ClienteNombre { get; set; } = string.Empty;
    public string NumeroCuenta { get; set; } = null!;
    public int TipoCuentaId { get; set; }
    public string TipoCuenta { get; set; } = string.Empty;
    public decimal SaldoInicial { get; set; }
    public List<MovimientoModel> Movimientos { get; set; } = new();
    public bool? Estado { get; set; }
}