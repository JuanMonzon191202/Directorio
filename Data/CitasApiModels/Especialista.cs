using System;
using System.Collections.Generic;

namespace CitasMedicasAPI.Data.CitasApiModels
{
    public partial class Especialista
    {
        public int Id { get; set; }
        public int? IdUsuario { get; set; } // Clave foránea a Usuarios
        public Usuario Usuario { get; set; } // Propiedad de navegación
        public int? IdResponsable { get; set; } // id llave foranea del usuario con Rol Admin
        public int? IdGupEspecialidad { get; set; } // id llave foranea para relacionar las especialidades guardadas
        public GrupEspecialidade GrupEspecialidade {get; set;} // Propiedad de navegación
        public string? Cargo { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }// correo de contacto
        public string? Ciudad { get; set; }
        public string? Pais { get; set; }
        public string? NumCedula { get; set; }
        public string? Descripcion { get; set; }
           
        // public virtual Administradore IdResponsableNavigation { get; set; }

    }
}
