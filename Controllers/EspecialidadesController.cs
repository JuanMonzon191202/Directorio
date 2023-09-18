using Microsoft.AspNetCore.Mvc;
using CitasMedicasAPI.Data;
using CitasMedicasAPI.Data.CitasApiModels;
using CitasMedicasAPI.Services;



[ApiController]
[Route("api/[controller]")]

public class EspecialidadesController : ControllerBase{

    private readonly EspecialidadesService _service;

    // referencia al contexto
    public EspecialidadesController(EspecialidadesService service){

        _service = service;
    }

    // getAll Especialidades

    [HttpGet("especialidades")]
    public IEnumerable<Especialidade> Get(){

        return _service.GetAll();
    }

    // GetById Especialidades
    [HttpGet("especialidades/{id}")]
    public ActionResult<Especialidade> GetById(int id){
        var especialidadFind = _service.GetById(id);

        if ( especialidadFind is null){
            return NotFound();
        }
        return especialidadFind;
    }

    // Crear nueva especialidad (post)
    [HttpPost("especialidades")]
    public IActionResult Create(Especialidade especialidade){
        var newEspecialidade = _service.Create(especialidade);

        return CreatedAtAction(nameof(GetById),new {id = newEspecialidade.Id}, newEspecialidade);
    }

    // actualizar especialidades ---se agrego parámetro en la URL para identificar la especialidad específica que se va a actualizar
    [HttpPut("especialidades/{id}")]
    public IActionResult Update(int id, Especialidade especialidade){
        if (id != especialidade.Id){
            return BadRequest("El ID proporcionado no coincide con el ID de la Especialidad.");
        }
        var especialidadeToUpdate = _service.GetById(id);

        if (especialidadeToUpdate == null){
            return NotFound($"Paciente con ID {id} no encontrado.");
        }
        _service.Update(especialidade);

        return NoContent();
    }
}

