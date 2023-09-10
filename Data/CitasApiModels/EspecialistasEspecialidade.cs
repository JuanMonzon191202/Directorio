using System;
using System.Collections.Generic;

namespace CitasMedicasAPI.Data.CitasApiModels;

public partial class EspecialistasEspecialidade
{
    public int Id { get; set; }

    public int? IdEspecialista { get; set; }

    public int? IdEspecialidad { get; set; }

    public virtual Especialidade? IdEspecialidadNavigation { get; set; }

    public virtual Especialista? IdEspecialistaNavigation { get; set; }
}
