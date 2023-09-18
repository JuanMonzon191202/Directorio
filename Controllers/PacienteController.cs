using Microsoft.AspNetCore.Mvc;
using CitasMedicasAPI.Services;
using Microsoft.AspNetCore.Http.Metadata;
using CitasMedicasAPI.Data.CitasApiModels;

namespace CitasMedicasAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PacientesController : ControllerBase
{
    // estructura base del controlador
    private readonly PacienteService _service;

    public PacientesController(PacienteService service)
    {
        //referenciando el contexto
        _service = service;
    }

    [HttpGet("paciente")]
    public IEnumerable<Paciente> Get()
    {
        return _service.GetAll();
    }

    [HttpGet("paciente/{id}")]
    public ActionResult<Paciente> GetById(int id)
    {
        var pacienteFind = _service.GetById(id);

        // respuesta si encontro o no el usuario con el id
        if (pacienteFind is null)
        {
            return NotFound();
        }
        return pacienteFind;
    }

    [HttpPost("paciente")]
    public IActionResult Create(Paciente paciente)
    {
        var newPaciente = _service.Create(paciente);

        return CreatedAtAction(nameof(GetById), new { id = newPaciente.Id }, newPaciente);
    }

    [HttpPut("paciente/{id}")]
    public IActionResult Update(int id, Paciente paciente)
    {
        if (id != paciente.Id)
        {
            return BadRequest("El ID proporcionado no coincide con el ID del paciente.");
        }

        var pacienteToUpdate = _service.GetById(id);

        if (pacienteToUpdate == null)
        {
            return NotFound($"Paciente con ID {id} no encontrado.");
        }

        _service.Update(paciente);

        return NoContent();
    }
}
