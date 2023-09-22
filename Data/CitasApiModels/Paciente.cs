using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CitasMedicasAPI.Data.CitasApiModels
{
    public partial class Paciente
    {
        public int Id { get; set; }

        [Required]
        public int IdUsuario { get; set; }
        public Usuario? Usuario { get; set; }

        [Required]
        public string Genero { get; set; }

        [Required]
        public string Telefono { get; set; }
        public string Ciudad { get; set; }

        [Required]
        public string Pais { get; set; }
        public DateTime? FechaNac { get; set; }
    }
}
