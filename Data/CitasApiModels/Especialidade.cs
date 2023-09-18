using System;
using System.Collections.Generic;

namespace CitasMedicasAPI.Data.CitasApiModels;

public partial class Especialidade
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Especialista> Especialista { get; set; } = new List<Especialista>();

    public virtual ICollection<GrupEspecialidade>GrupEspecialidades { get; set; } = new List<GrupEspecialidade>();
}
