using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CitasMedicasAPI.Data.CitasApiModels;

public partial class RolesUsuario
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string? NombreRol { get; set; }

}
