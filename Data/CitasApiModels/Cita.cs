using System;
using System.Collections.Generic;

namespace CitasMedicasAPI.Data.CitasApiModels;

public partial class Cita
{
    public int Id { get; set; }

    public int? IdPaciente { get; set; } // id llave foranea del usuario que pertenezca a los pacientes 

    public int? IdEspecialista { get; set; } // id llave foranea del usuario que pertenezca a los especialistas 

    public int? IdCmc { get; set; }  // id llave foranea del usuario que pertenezca a los CMC (Centro medico o Clinicas)

    public DateTime? FechaCita { get; set; }

    public TimeSpan? HoraInicio { get; set; }

    public TimeSpan? HoraFin { get; set; }

    public string? Estado { get; set; }

    public bool? Eliminado { get; set; }

    
}
