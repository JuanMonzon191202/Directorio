using System;
using System.Collections.Generic;

namespace CitasMedicasAPI.Data.CitasApiModels;

public partial class Administradore
{
    public int Id { get; set; }

    public virtual ICollection<CentrosMedicosClinica> CentrosMedicosClinicas { get; set; } = new List<CentrosMedicosClinica>();

    public virtual ICollection<Especialista> Especialista { get; set; } = new List<Especialista>();
    
}
