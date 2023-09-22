using System;
using System.ComponentModel.DataAnnotations;

namespace CitasMedicasAPI.Data.CitasApiModels
{
    public partial class Usuario
    {
        public int Id { get; set; }

        [Required]
        public int IdRol { get; set; }

        public RolesUsuario RolesUsuario { get; set; }

        [Required]
        [StringLength(50)] // Puedes ajustar la longitud máxima según tus necesidades
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)] // Puedes ajustar la longitud máxima según tus necesidades
        public string Apellido { get; set; }

        [Required]
        [EmailAddress] // Valida que sea una dirección de correo electrónico válida
        public string Correo { get; set; }

        [Required]
        [DataType(DataType.Password)] // Indica que es un campo de contraseña
        public string Contraseña { get; set; }

        [Required]
        [DataType(DataType.DateTime)] // Indica que es un campo de fecha y hora
        public DateTime FechaRegistro { get; set; }

        [Required]
        public bool Activo { get; set; }
    }
}
