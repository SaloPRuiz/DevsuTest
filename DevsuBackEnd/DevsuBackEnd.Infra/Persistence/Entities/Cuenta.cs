using System.ComponentModel.DataAnnotations.Schema;

namespace DevsuBackEnd.Infra.Persistence.Entities;

[Table("Cuenta")]
public partial class Cuenta
{
    public int CuentaId { get; set; }
    public string NumeroCuenta { get; set; } = null!;
    public int TipoCuentaId { get; set; }
    public decimal SaldoInicial { get; set; }
    public bool? Estado { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime? FechaModificacion { get; set; }
    public int ClienteId { get; set; }
    public virtual Cliente Cliente { get; set; } = null!;
    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
    public virtual TipoCuenta TipoCuenta { get; set; } = null!;
}
