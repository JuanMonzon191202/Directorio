﻿using System;
using System.Collections.Generic;

namespace CitasMedicasAPI.Data.CitasApiModels;

public partial class Cita
{
    public int Id { get; set; }

    public int? IdPaciente { get; set; }

    public int? IdEspecialista { get; set; }

    public int? IdCmc { get; set; }

    public DateTime? FechaCita { get; set; }

    public TimeSpan? HoraInicio { get; set; }

    public TimeSpan? HoraFin { get; set; }

    public string? Estado { get; set; }

    public bool? Eliminado { get; set; }

    public virtual CentrosMedicosClinica? IdCmcNavigation { get; set; }

    public virtual Especialista? IdEspecialistaNavigation { get; set; }

    public virtual Paciente? IdPacienteNavigation { get; set; }

    public virtual ICollection<Notificacione> Notificaciones { get; set; } = new List<Notificacione>();
}
