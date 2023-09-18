using System;
using System.Collections.Generic;

namespace CitasMedicasAPI.Data.CitasApiModels;

public partial class CentrosMedicosClinica
{
    public int Id { get; set; }

    public int? IdRol { get; set; }

    public int? IdResponsable { get; set; }

    public int? IdEspecialistaEspecialidad { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public int? PersonalCount { get; set; }

    public string? Ciudad { get; set; }

    public string? Pais { get; set; }

    public string? Telefono{ get; set; }

    public string? Correo { get; set; }

    public string? SitioWeb { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual GrupEspecialidade? IdGrupEspecialidadeNavigation { get; set; }

    public virtual Administradore? IdResponsableNavigation { get; set; }

    public virtual RolesUsuario? IdRolNavigation { get; set; }
}
