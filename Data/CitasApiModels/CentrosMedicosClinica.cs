using System;
using System.Collections.Generic;

namespace CitasMedicasAPI.Data.CitasApiModels;

public partial class CentrosMedicosClinica
{
    public int Id { get; set; }

    public int? IdRol { get; set; }

    public int? IdResponsable { get; set; }

    public string? NombreCompletoResponsable { get; set; }

    public string? ResponsableCorreo { get; set; }

    public string? ResponsableTelefono { get; set; }

    public string? ResponsableCiudad { get; set; }

    public string? NombreCmc { get; set; }

    public string? DireccionCmc { get; set; }

    public int? PersonalCountCmc { get; set; }

    public string? CiudadCmc { get; set; }

    public string? PaisCmc { get; set; }

    public string? TelefonoCmc { get; set; }

    public string? CorreoCmc { get; set; }

    public string? SitioWebCmc { get; set; }

    public string? DescripcionCmc { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual Administradore? IdResponsableNavigation { get; set; }

    public virtual RolesUsuario? IdRolNavigation { get; set; }
}
