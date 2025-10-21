namespace DevsuBackEnd.Domain.Models;

public class TipoCuentaModel
{
    public int TipoCuentaId { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
}