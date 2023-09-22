using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CitasMedicasAPI.Data.CitasApiModels;

public partial class Especialidade
{
    public int Id { get; set; }

    [Required]
    public string? Nombre { get; set; }
}
