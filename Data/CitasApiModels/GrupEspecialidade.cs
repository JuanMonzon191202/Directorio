using System;
using System.Collections.Generic;

namespace CitasMedicasAPI.Data.CitasApiModels;

public partial class GrupEspecialidade
{
    public int Id { get; set; }

    public int? IdEspecialista { get; set; } // llave foranea para relacionar los especialistas

    public int? IdCMC { get; set; } // llave foranea para relacionar los CMC

    public int IdEspecialidad { get; set; } // llave foranea para relacionar las especialidades

    public virtual ICollection<CentrosMedicosClinica> CentrosMedicosClinicas { get; set; } =
        new List<CentrosMedicosClinica>();

    public virtual Especialidade? IdEspecialidadNavigation { get; set; }

    public virtual Especialista? IdEspecialistaNavigation { get; set; }

    public virtual CentrosMedicosClinica? idCentrosMedicosClinicaNavigation { get; set; }
}
