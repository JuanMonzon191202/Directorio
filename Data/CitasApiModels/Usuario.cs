using System;
using System.Collections.Generic;

namespace CitasMedicasAPI.Data.CitasApiModels
{
    public partial class Usuario
    {
        public int Id { get; set; }

        public int? IdRol { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? Correo { get; set; }

        public string? Contraseña { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public bool? Activo { get; set; }
    }
}
