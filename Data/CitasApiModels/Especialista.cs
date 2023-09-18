using System;
using System.Collections.Generic;

namespace CitasMedicasAPI.Data.CitasApiModels
{
    public partial class Especialista
    {
        public int Id { get; set; }
        public int? IdResponsable { get; set; }
        public int? IdEspecialistaEspecialidad { get; set; }
        public string? Cargo { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }// correo de contacto
        public string? Ciudad { get; set; }
        public string? Pais { get; set; }
        public string? NumCedula { get; set; }
        public string? Descripcion { get; set; }
        public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
        public virtual ICollection<GrupEspecialidade> GrupEspecialidades { get; set; } = new List<GrupEspecialidade>();        
        public virtual Administradore IdResponsableNavigation { get; set; }

    }
}
