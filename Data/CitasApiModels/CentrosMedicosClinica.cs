using System;
using System.Collections.Generic;

namespace CitasMedicasAPI.Data.CitasApiModels
{
    public partial class CentrosMedicosClinica
    {
        public int Id { get; set; }
        public int? IdRol { get; set; } // id llave foranea para los RolesUsuario
        public int? IdResponsable { get; set; } // id llave foranea del usuario con Rol Admin
         public int? IdUsuario { get; set; } // Clave foránea a Usuarios
        public Usuario Usuario { get; set; } // Propiedad de navegación
       public int? IdGupEspecialidad { get; set; } // id llave foranea para relacionar las especialidades guardadas
        public GrupEspecialidade GrupEspecialidade {get; set;} // Propiedad de navegación id llave foranea para relacionar las especialidades guardadas
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public int? PersonalCount { get; set; }
        public string? Ciudad { get; set; }
        public string? Pais { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? SitioWeb { get; set; }
        public string? Descripcion { get; set; }

    }
}
