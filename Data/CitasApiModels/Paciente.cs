using System;
using System.Collections.Generic;

namespace CitasMedicasAPI.Data.CitasApiModels;

public partial class Paciente
{
    public int Id { get; set; }

    public int? IdRol { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Correo { get; set; }

    public string? Contrasenia { get; set; }

    public DateTime? FechaNac { get; set; }

    public string? Genero { get; set; }

    public string? Telefono { get; set; }

    public string? Ciudad { get; set; }

    public string? Pais { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public bool? Activo { get; set; }
}
