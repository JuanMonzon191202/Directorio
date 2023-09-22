using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CitasMedicasAPI.Data.CitasApiModels
{
    public partial class Especialista
    {
        public int Id { get; set; }

        [Required]
        public int? IdUsuario { get; set; } // Clave foránea a Usuarios
        public Usuario Usuario { get; set; } // Propiedad de navegación

        [Required]
        public int? IdResponsable { get; set; } // id llave foranea del usuario con Rol Admin

        [Required]
        public int? IdGupEspecialidad { get; set; } // id llave foranea para relacionar las especialidades guardadas
        public GrupEspecialidade GrupEspecialidade { get; set; } // Propiedad de navegación

        [Required]
        public string? Cargo { get; set; }

        [Required]
        public string? Direccion { get; set; }

        [Required]
        public string? Telefono { get; set; }

        [Required]
        public string? Correo { get; set; } // correo de contacto

        [Required]
        public string? Ciudad { get; set; }

        [Required]
        public string? Pais { get; set; }

        [Required]
        public string? NumCedula { get; set; }

        [Required]
        public string? Descripcion { get; set; }

        // public virtual Administradore IdResponsableNavigation { get; set; }
    }
}
