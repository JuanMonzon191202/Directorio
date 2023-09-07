using Microsoft.AspNetCore.Mvc;
using CitasMedicasAPI.Data;
using CitasMedicasAPI.Data.CitasApiModels;


[Route("api/[controller]")]
[ApiController]



public class EspecialistasController : ControllerBase
{
    // Métodos para manejar las operaciones relacionadas con especialistas
    private readonly DbdirectorioContext _context;

    public EspecialistasController(DbdirectorioContext context)
    {

        //referenciando el contexto 
        _context = context;

    }

    /* 
    metodo para listar los especialistas con un get 
    */

    [HttpGet("getEspecialista")]
    public IEnumerable<Especialista> Get()
    {
        return _context.Especialistas.ToList();
    }

    /*
    metodo get by id para los especialistas
    */

    [HttpGet("getEspecialista/{id}")]
    public ActionResult<Especialista> GetById(int id)
    {
        var especialistaFind = _context.Especialistas.Find(id);
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
        _context.Especialistas.Add(especialista);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = especialista.Id }, especialista);
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
        var existingEspecialista = _context.Especialistas.Find(id);
        if (existingEspecialista is null)
        {
            return NotFound();
        }

        existingEspecialista.NombreCompleto = especialista.NombreCompleto;
        existingEspecialista.Correo = especialista.Correo;
        existingEspecialista.Contrasenia = especialista.Contrasenia;
        existingEspecialista.FechaNac = especialista.FechaNac;
        existingEspecialista.Genero = especialista.Genero;
        existingEspecialista.Direccion = especialista.Direccion;
        existingEspecialista.Telefono = especialista.Telefono;
        existingEspecialista.Ciudad = especialista.Ciudad;
        existingEspecialista.Pais = especialista.Pais;

        _context.SaveChanges();

        return NoContent();
    }



}
