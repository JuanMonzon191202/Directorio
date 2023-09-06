using System;
using System.Collections.Generic;

namespace CitasMedicasAPI.Data.CitasApiModels;

public partial class Notificacione
{
    public int Id { get; set; }

    public int? IdCita { get; set; }

    public string? Contenido { get; set; }

    public bool? Leido { get; set; }

    public DateTime? FechaEnvio { get; set; }
}
