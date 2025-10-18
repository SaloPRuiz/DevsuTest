namespace DevsuBackEnd.Domain.Models;

public class ClienteModel
{
    public int ClienteId { get; set; }
    public int PersonaId { get; set; }
    public PersonaModel Persona { get; set; } = new();
    public string? Contrasena { get; set; }
    public bool? Estado { get; set; }   
}