using Microsoft.AspNetCore.Mvc;
using CitasMedicasAPI.Data;
using CitasMedicasAPI.Data.CitasApiModels;
using CitasMedicasAPI.Services;



[ApiController]
[Route("api/[controller]")]


public class EspecialistasController : ControllerBase
{
    // Métodos para manejar las operaciones relacionadas con especialistas
    private readonly EspecialistaService _service;

    public EspecialistasController(EspecialistaService service)
    {

        //referenciando el contexto 
        _service = service;

    }

    /* 
    metodo para listar los especialistas con un get 
    */

    [HttpGet("getEspecialista")]
    public IEnumerable<Especialista> Get()
    {
        return _service.GetAll();
    }

    /*
    metodo get by id para los especialistas
    */

    [HttpGet("getEspecialista/{id}")]
    public ActionResult<Especialista> GetById(int id)
    {
        var especialistaFind = _service.GetById(id);

        if (especialistaFind is null)
        {
            return NotFound();
        }
        return especialistaFind;
    }
    //TODO delete, , post


    /*
   metodo post para Especialistas
   */

    [HttpPost("postEspecialista")]
    public IActionResult Create(Especialista especialista)
    {
        var newEspecialista = _service.Create(especialista);
    
        return CreatedAtAction(nameof(GetById), new { id = newEspecialista.Id }, newEspecialista);
    }

    /*
    metodo put para especialistas
    */

    [HttpPut("putEspecialista/{id}")]
    public IActionResult Update(int id, Especialista especialista)
    {
        if (id != especialista.Id)
        {
            return BadRequest();
        }
        var especialistaToUpdate = _service.GetById(id);

        if (especialistaToUpdate is not null)
        {
            _service.Update(especialista);
            return NoContent();
        }
        else{
            
            return NotFound();
        }

    }



}
