using System;
using System.Collections.Generic;

namespace CitasMedicasAPI.Data.CitasApiModels
{
    public partial class Paciente
    {
        public int Id { get; set; }

        public int? IdRol { get; set; }

        public string? Genero { get; set; }

        public string? Telefono { get; set; }

        public string? Ciudad { get; set; }

        public string? Pais { get; set; }

        public DateTime? FechaNac { get; set; }

        public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

       public virtual RolesUsuario? IdRolNavigation { get; set; }
    }
}

