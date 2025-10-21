using System.ComponentModel.DataAnnotations.Schema;

namespace DevsuBackEnd.Infra.Persistence.Entities;

[Table("TipoCuenta")]
public partial class TipoCuenta
{
    public int TipoCuentaId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<Cuenta> Cuenta { get; set; } = new List<Cuenta>();
}
