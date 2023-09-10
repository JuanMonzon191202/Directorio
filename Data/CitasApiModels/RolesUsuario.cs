using System;
using System.Collections.Generic;

namespace CitasMedicasAPI.Data.CitasApiModels;

public partial class RolesUsuario
{
    public int Id { get; set; }

    public string? NombreRol { get; set; }

    public virtual ICollection<CentrosMedicosClinica> CentrosMedicosClinicas { get; set; } = new List<CentrosMedicosClinica>();

    public virtual ICollection<Especialista> Especialista { get; set; } = new List<Especialista>();

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
