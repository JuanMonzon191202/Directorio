using Microsoft.AspNetCore.Mvc;
using CitasMedicasAPI.Services;
using CitasMedicasAPI.Data.CitasApiModels;
using Microsoft.Identity.Client;
using System.Text.RegularExpressions;

namespace CitasMedicasAPI.Controllers;

[ApiController]
[Route("api[controller]")]
public class UsuarioController : Controller
{
    private readonly UsuarioService _service;

    public UsuarioController(UsuarioService service)
    {
        _service = service;
    }

    [HttpGet("usuario")]
    public IEnumerable<Usuario> Get()
    {
        return _service.GetAll();
    }

    [HttpPost("usuario")]
    public IActionResult Create(Usuario usuario)
    {
        // Consulta el RolesUsuario correspondiente al Id de rol proporcionado en el modelo Usuario.
        var rolUsuario = _service.GetRolesUsuarioById(usuario.IdRol);

        if (rolUsuario == null)
        {
            // Maneja el caso en el que el rol especificado no existe.
            return BadRequest("El rol especificado no existe.");
        }

        // Asigna el objeto RolesUsuario existente al usuario.
        Console.Write($"mmda de rol :{rolUsuario.Id}");
        usuario.RolesUsuario = rolUsuario;
        Console.Write($"mmda de rol :{rolUsuario.NombreRol}");
        // Agrega el usuario al contexto y guárdalo en la base de datos.
        var newUsuario = _service.Create(usuario);

        return CreatedAtAction(nameof(GetById), new { id = newUsuario.Id }, newUsuario);
    }

    [HttpGet("usuario/{id}")]
    public ActionResult<Usuario> GetById(int id)
    {
        var userFind = _service.GetById(id);

        if (userFind is null)
        {
            return NotFound("Usuario no encontrado");
        }

        // Obtener el nombre del rol del usuario
        var roleName = userFind.RolesUsuario?.NombreRol;

        // Crear un nuevo objeto con el nombre del rol en lugar del ID
        var userResponse = new
        {
            id = userFind.Id,
            idRol = roleName,
            nombre = userFind.Nombre,
            apellido = userFind.Apellido,
            correo = userFind.Correo,
            contraseña = userFind.Contraseña,
            fechaRegistro = userFind.FechaRegistro,
            activo = userFind.Activo
        };

        return Ok(userResponse);
    }

    //

    [HttpPut("usuario/{id}")]
    public IActionResult Update(int id, Usuario user)
    {
        if (id != user.Id)
        {
            return BadRequest("El ID proporcionado no coincide con el ID del usuario.");
        }
        var userToUpdate = _service.GetById(id);

        if (userToUpdate == null)
        {
            return NotFound($"Usuario con ID {id} no encontrado.");
        }
        _service.Update(user);
        return NoContent();
    }
}
