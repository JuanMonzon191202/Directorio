using Microsoft.AspNetCore.Mvc;
using CitasMedicasAPI.Data;
using CitasMedicasAPI.Data.CitasApiModels;

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


}
