namespace DevsuBackEnd.Infra.Persistence.Entities;

public partial class Persona
{
    public int PersonaId { get; set; }
    public string Nombre { get; set; } = null!;
    public bool? Genero { get; set; }
    public short? Edad { get; set; }
    public string Identificacion { get; set; } = null!;
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime? FechaModificacion { get; set; }
    public bool? Estado { get; set; }
    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
