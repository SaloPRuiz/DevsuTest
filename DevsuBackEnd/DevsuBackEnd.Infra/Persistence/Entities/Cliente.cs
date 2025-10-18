using System;
using System.Collections.Generic;

namespace DevsuBackEnd.Infra.Persistence.Entities;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public int PersonaId { get; set; }

    public string? Contrasena { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public bool? Estado { get; set; }

    public virtual Persona Persona { get; set; } = null!;
}
