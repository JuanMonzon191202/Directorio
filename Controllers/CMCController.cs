using Microsoft.AspNetCore.Mvc;
using CitasMedicasAPI.Data;
using CitasMedicasAPI.Data.CitasApiModels;
using CitasMedicasAPI.Services;


[Route("api/[controller]")]
[ApiController]
public class CMCController : ControllerBase
{
    // Métodos para manejar las operaciones relacionadas con especialistas
    private readonly CMCService _service ;



    public CMCController(CMCService service)
    {
        _service = service;
    }

    /* 
   metodo para listar los CMC [centros medicos o Clinicas] con un get 
   */

    [HttpGet("centrosmedicosclinicas")]
    public IEnumerable<CentrosMedicosClinica> Get()
    {
        return _service.GetAll();
    }

    /*
    metodo GetById para las CMC
    */

    [HttpGet("centrosmedicosclinicas/{id}")]
    public ActionResult<CentrosMedicosClinica> GetById(int id){
        var CMCFind = _service.GetById(id);

        if (CMCFind is null){
            return NotFound();
        }
        return CMCFind;
    }

    /*
    metodo crear con post nuevo CMC
    */

    [HttpPost("centrosmedicosclinicas")]
    public IActionResult Create(CentrosMedicosClinica cmc){
        var newCMC = _service.Create(cmc);

        return CreatedAtAction(nameof(GetById),new {id = newCMC.Id}, newCMC);
    }

    [HttpPut("centrosmedicosclinicas/{id}")]
    public IActionResult Update(int id, CentrosMedicosClinica cmc){
        if (id != cmc.Id){
            return BadRequest("El ID proporcionado no coincide con el ID del paciente.");
        }
        var cmcToUpdate = _service.GetById(id);

        if (cmcToUpdate == null){
            return NotFound($"Paciente con ID {id} no encontrado.");
        }
        _service.Update(cmc);
        return NoContent();
    }

}