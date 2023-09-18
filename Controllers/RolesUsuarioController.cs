using Microsoft.AspNetCore.Mvc;
using CitasMedicasAPI.Services;
using CitasMedicasAPI.Data.CitasApiModels;
using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic;

namespace CitasMedicasAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RolesUsuarioController : ControllerBase
{
    private readonly RolesService _service;

    public RolesUsuarioController(RolesService service)
    {
        _service = service;
    }

    [HttpGet("roles")]
    public IEnumerable<RolesUsuario> Get()
    {
        return _service.GetAll();
    }

    [HttpGet("roles/{id}")]
    public ActionResult<RolesUsuario> GetById(int id)
    {
        var rolFind = _service.GetById(id);

        if (rolFind is null)
        {
            return NotFound("Rol no encontrado...");
        }
        return rolFind;
    }

    [HttpPost("roles")]
    public IActionResult Create(RolesUsuario rol)
    {
        var newRol = _service.Create(rol);
        return CreatedAtAction(nameof(GetById), new { id = newRol.Id }, newRol);
    }

    [HttpPut("roles/{id}")]
    public IActionResult Update(int id, RolesUsuario rol)
    {
        if (id != rol.Id)
        {
            return BadRequest("El ID proporcionado no coincide con el ID del Rol seleccionado.");
        }
        var rolToUpdate = _service.GetById(id);

        if (rolToUpdate == null)
        {
            return NotFound($"Rol con ID {id} no encontrado.");
        }

        // Utiliza rolToUpdate en lugar de rol para la actualización.
        _service.Update(rol);

        return NoContent();
    }
}
