using System;
using System.Collections.Generic;

namespace CitasMedicasAPI.Data.CitasApiModels;

public partial class Administradore
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Correo { get; set; }

    public string? Contraseña { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<CentrosMedicosClinica> CentrosMedicosClinicas { get; set; } = new List<CentrosMedicosClinica>();

    public virtual ICollection<Especialista> Especialista { get; set; } = new List<Especialista>();
}
