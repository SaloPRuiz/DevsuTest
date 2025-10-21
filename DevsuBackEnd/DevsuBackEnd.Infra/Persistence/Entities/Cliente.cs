namespace DevsuBackEnd.Infra.Persistence.Entities;

public partial class Cliente
{
    public int ClienteId { get; set; }
    public int PersonaId { get; set; }
    public string? Contrasena { get; set; }
    public DateTime? FechaCreacion { get; set; }
    public DateTime? FechaModificacion { get; set; }
    public bool? Estado { get; set; }
    public virtual ICollection<Cuenta> Cuenta { get; set; } = new List<Cuenta>();
    public virtual Persona Persona { get; set; } = null!;
}
