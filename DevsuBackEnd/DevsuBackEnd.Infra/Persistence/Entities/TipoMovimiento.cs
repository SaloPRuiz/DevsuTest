namespace DevsuBackEnd.Infra.Persistence.Entities;

public partial class TipoMovimiento
{
    public int TipoMovimientoId { get; set; }
    public string Nombre { get; set; } = null!;
    public bool EsPositivo { get; set; }
    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
}
