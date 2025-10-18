namespace DevsuBackEnd.Domain.Models;

public class PersonaModel
{
    public int PersonaId { get; set; }
    public string Nombre { get; set; } = null!;
    public bool? Genero { get; set; }
    public short? Edad { get; set; }
    public string Identificacion { get; set; } = null!;
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public bool? Estado { get; set; }
}