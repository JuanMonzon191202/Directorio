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

    [HttpGet("especialista")]
    public IEnumerable<Especialista> Get()
    {
        return _service.GetAll();
    }

    /*
    metodo get by id para los especialistas
    */

    [HttpGet("especialista/{id}")]
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

    [HttpPost("especialista")]
    public IActionResult Create(Especialista especialista)
    {
        var newEspecialista = _service.Create(especialista);

        return CreatedAtAction(nameof(GetById), new { id = newEspecialista.Id }, newEspecialista);
    }
    /*
    prueba busqueda con where
    */

    

        // Nueva acción GET para buscar especialistas por especialidad
    [HttpGet("por-especialidad/{especialidadId}")]
    public IActionResult GetEspecialistasByEspecialidad(int especialidadId)
    {
        var especialistas = _service.GetEspecialistasByEspecialidad(especialidadId);
        
        if (especialistas == null || !especialistas.Any())
        {
            return NotFound("No se encontraron especialistas para esta especialidad.");
        }

        return Ok(especialistas);
    }

    [HttpGet("especialistas-y-cmc/{especialidadId}")]
    public IActionResult GetEspecialistasYCMCPorEspecialidad(int especialidadId)
    {
        var resultado = _service.GetEspecialistasYCMCPorEspecialidad(especialidadId);

        if (resultado == null)
        {
            return NotFound();
        }

        return Ok(resultado);
    }
    /*
    metodo put para especialistas
    */

    [HttpPut("especialista/{id}")]
    public IActionResult Update(int id, Especialista especialista)
    {
        if (id != especialista.Id)
        {
            return BadRequest();
        }

        var especialistaToUpdate = _service.GetById(id);

        if (especialistaToUpdate is null)
        {
            return NotFound();
        }

        // Actualiza solo los campos que no son nulos en la solicitud
       

        if (especialista.Correo != null)
        {
            especialistaToUpdate.Correo = especialista.Correo;
        }

      

        if (especialista.Direccion != null)
        {
            especialistaToUpdate.Direccion = especialista.Direccion;
        }

        if (especialista.Telefono != null)
        {
            especialistaToUpdate.Telefono = especialista.Telefono;
        }

        if (especialista.Ciudad != null)
        {
            especialistaToUpdate.Ciudad = especialista.Ciudad;
        }

        if (especialista.Pais != null)
        {
            especialistaToUpdate.Pais = especialista.Pais;
        }

        if (especialista.NumCedula != null)
        {
            especialistaToUpdate.NumCedula = especialista.NumCedula;
        }

       

        _service.Update(especialistaToUpdate); // Actualiza en la base de datos no se como es que funciona pero funciona
        //TODO Corregir esto, las evaluaciones van en el service y ya se pasaria especialista como parametro :)
        return NoContent();
    }
}
