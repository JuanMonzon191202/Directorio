using CitasMedicasAPI.Services;
using CitasMedicasAPI.Data.CitasApiModels;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicasAPI.Controllers;

[ApiController]
[Route("api[controller]")]
public class AdminsController : ControllerBase
{
    private readonly AdminService _service;

    public AdminsController(AdminService service)
    {
        _service = service;
    }
    /*
        metodo get all admins
    */

    [HttpGet("admins")]
    public IEnumerable<Administradore> Get()
    {
        return _service.GetAll();
    }

    [HttpGet("adminFind/{id}")]
    public ActionResult<Administradore> GetById(int id){

        var adminFind = _service.GetById(id);

        if (adminFind is null){
            return NotFound();
        }
        return adminFind;

    }
    /*
    post para crear admins
    */
    [HttpPost("createAdmin")]
    public IActionResult Create(Administradore admin){
        var newAdmin = _service.Create(admin);
        return CreatedAtAction(nameof(GetById), new{id = newAdmin.Id}, newAdmin);

    }

    /*
    creacion del put para actualizar informacion del admin
    */
    [HttpPut("updateAdmin/{id}")]
    public IActionResult Update(int id, Administradore admin){
        if (id != admin.Id){
            return BadRequest("El ID proporcionado no coincide con el ID del Admin.");

        }
        var adminToUpdate = _service.GetById(id);

        if (adminToUpdate == null){
            return NotFound($"Admin con ID {id} no encontrado.");
        }
        _service.Update(admin);

        return NoContent();
    }
}
