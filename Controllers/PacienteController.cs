using Microsoft.AspNetCore.Mvc;
using CitasMedicasAPI.Data;
using CitasMedicasAPI.Data.CitasApiModels;
using Microsoft.AspNetCore.Http.Metadata;

namespace CitasMedicasAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PacientesController : ControllerBase
{

    // estructura base del controlador 
    private readonly DbdirectorioContext _context;
    public PacientesController(DbdirectorioContext context)
    {

        //referenciando el contexto 
        _context = context;

    }

    /* 
    metodos para manejar las solicitudes Get paciente
    /api/Paciente/getpaciente

    */
    [HttpGet("getpaciente")]
    public IEnumerable<Paciente> Get()
    {
        return _context.Pacientes.ToList();
    }
    /*
    metodos para manejar las solicitudes get by id pacientes
    /api/Paciente/getpaciente/{id}
    */

    [HttpGet("getpaciente/{id}")]
    public ActionResult<Paciente> GetById(int id)
    {
        var pacienteFind = _context.Pacientes.Find(id);

        // respuesta si encontro o no el usuario con el id  
        if (pacienteFind is null)
        {
            return NotFound();
        }
        return pacienteFind;
    }
    /*
    metodo post para pacientes
    */
    [HttpPost("postpaciente")]
    public IActionResult Create(Paciente paciente){
        _context.Pacientes.Add(paciente);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById),new {id = paciente.Id}, paciente); 
    }
    /*
    metodo put para pacientes
    */
    [HttpPut("putpaciente/{id}")]
    // verificando  que el paciente exista
    public IActionResult Update(int id, Paciente paciente){
        if(id != paciente.Id){
            return BadRequest();
    
        }
        var existingPaciente = _context.Pacientes.Find(id);
        if (existingPaciente is null){
            return NotFound() ;
        }
        //campos en la DB
        existingPaciente.Nombre = paciente.Nombre;
        existingPaciente.Apellido = paciente.Apellido;
        existingPaciente.Correo = paciente.Correo;
        existingPaciente.Contrasenia = paciente.Contrasenia;
        existingPaciente.Genero = paciente.Genero;
        existingPaciente.Telefono = paciente.Telefono;
        existingPaciente.Ciudad = paciente.Ciudad;
        existingPaciente.Pais = paciente.Pais;

        _context.SaveChanges();

        return NoContent();
    }


}
