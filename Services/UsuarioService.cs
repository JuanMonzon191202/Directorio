namespace CitasMedicasAPI.Services;

using CitasMedicasAPI.Data;
using CitasMedicasAPI.Data.CitasApiModels;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class UsuarioService
{

    private readonly DbdirectorioContext _context;

    public UsuarioService(DbdirectorioContext context)
    {

        _context = context;
    }

    public IEnumerable<Usuario> GetAll()
    {
        return _context.Usuarios.ToList();
    }

   public Usuario GetById(int id)
{
    return _context.Usuarios
        .Include(u => u.IdRolNavigation) // Incluye la propiedad de navegación IdRolNavigation
        .SingleOrDefault(u => u.Id == id);
}

    public Usuario Create(Usuario newUsuario)
    {
        _context.Usuarios.Add(newUsuario);
        _context.SaveChanges();

        return newUsuario;

    }

    public void Update(Usuario usuario)
    {
        var existingUsuario = GetById(usuario.Id);

        if (existingUsuario != null)
        {
            if (usuario.IdRol != null)
            {

            }
            if (usuario.Nombre != null)
            {
                existingUsuario.Nombre = usuario.Nombre;
            }
            if (usuario.Apellido != null)
            {
                existingUsuario.Nombre = usuario.Apellido;
            }
            if (usuario.Correo != null)
            {
                existingUsuario.Correo = usuario.Correo;
            }
            if (usuario.Contraseña != null)
            {
                existingUsuario.Contraseña = usuario.Contraseña;
            }
            if (usuario.FechaRegistro != null)
            {

            }
            if (usuario.Activo != null)
            {
                existingUsuario.Activo = usuario.Activo;
            }
        }
    }

}