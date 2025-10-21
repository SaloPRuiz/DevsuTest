namespace DevsuBackEnd.Infra.Persistence.Entities;

public partial class Movimiento
{
    public int MovimientoId { get; set; }
    public int CuentaId { get; set; }
    public int TipoMovimientoId { get; set; }
    public DateTime FechaMovimiento { get; set; }
    public decimal Valor { get; set; }
    public decimal Saldo { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime? FechaModificacion { get; set; }
    public bool? Estado { get; set; }
    public virtual Cuenta Cuenta { get; set; } = null!;
    public virtual TipoMovimiento TipoMovimiento { get; set; } = null!;
}
