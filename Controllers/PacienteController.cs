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


    [HttpGet("getpaciente")]
    public IEnumerable<Paciente> Get()
    {
        return _service.GetAll();
    }


    [HttpGet("getpaciente/{id}")]
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

    [HttpPost("postpaciente")]
    public IActionResult Create(Paciente paciente)
    {
        var newPaciente = _service.Create(paciente);

        return CreatedAtAction(nameof(GetById), new { id = newPaciente.Id }, newPaciente);
    }

    [HttpPut("putpaciente/{id}")]
    // verificando  que el paciente exista
    public IActionResult Update(int id, Paciente paciente)
    {
        if (id != paciente.Id)
        {
            return BadRequest();

        }
        var pacienteToUpdate = _service.GetById(id);

        if (pacienteToUpdate is not null)
        {
            _service.Update(pacienteToUpdate);
            return NoContent();

        }
        else
        {
            return NotFound();
        }
    }


}
