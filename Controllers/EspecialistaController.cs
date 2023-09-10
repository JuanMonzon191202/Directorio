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

    if (especialistaToUpdate is null)
    {
        return NotFound();
    }

    // Actualiza solo los campos que no son nulos en la solicitud
    if (especialista.NombreCompleto != null)
    {
        especialistaToUpdate.NombreCompleto = especialista.NombreCompleto;
    }

    if (especialista.Correo != null)
    {
        especialistaToUpdate.Correo = especialista.Correo;
    }

    if (especialista.Contrasenia != null)
    {
        especialistaToUpdate.Contrasenia = especialista.Contrasenia;
    }

    if (especialista.FechaNac != null)
    {
        especialistaToUpdate.FechaNac = especialista.FechaNac;
    }

    if (especialista.Genero != null)
    {
        especialistaToUpdate.Genero = especialista.Genero;
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

    if (especialista.FechaRegistro != null)
    {
        especialistaToUpdate.FechaRegistro = especialista.FechaRegistro;
    }

    if (especialista.Activo != null)
    {
        especialistaToUpdate.Activo = especialista.Activo;
    }

    _service.Update(especialistaToUpdate); // Actualiza en la base de datos no se como es que funciona pero funciona
    //TODO Corregir esto, las evaluaciones van en el service y ya se pasaria especialista como parametro :)
    return NoContent();
}





}
