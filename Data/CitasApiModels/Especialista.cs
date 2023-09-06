using System;
using System.Collections.Generic;

namespace CitasMedicasAPI.Data.CitasApiModels;

public partial class Especialista
{
    public int Id { get; set; }

    public int? IdRol { get; set; }

    public int? IdResponsable { get; set; }

    public int? IdEspecialidad { get; set; }

    public string? NombreCompleto { get; set; }

    public string? Correo { get; set; }

    public string? Contrasenia { get; set; }

    public DateTime? FechaNac { get; set; }

    public string? Genero { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Ciudad { get; set; }

    public string? Pais { get; set; }

    public string? NumCedula { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public bool? Activo { get; set; }
}
