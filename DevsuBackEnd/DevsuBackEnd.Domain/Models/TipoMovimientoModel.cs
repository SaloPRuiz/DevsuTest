namespace DevsuBackEnd.Domain.Models;

public class TipoMovimientoModel
{
    public int TipoMovimientoId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public bool EsPositivo { get; set; }
}