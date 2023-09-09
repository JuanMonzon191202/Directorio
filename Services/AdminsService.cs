namespace CitasMedicasAPI.Services;

using CitasMedicasAPI.Data;
using CitasMedicasAPI.Data.CitasApiModels;

public class AdminService
{
    private readonly DbdirectorioContext _context;

    public AdminService(DbdirectorioContext context)
    {
        _context = context;
    }

    /*
    metodos para manejar las solicitudes get para administradores
    */
    public IEnumerable<Administradore> GetAll()
    {
        return _context.Administradores.ToList();
    }

    /*
    metodos para GetById administradores
    */

    public Administradore? GetById(int id)
    {
        return _context.Administradores.Find(id);
    }

    /*
    metodo post para administradores
    */

    public Administradore Create(Administradore newAdmin)
    {
        _context.Administradores.Add(newAdmin);
        _context.SaveChanges();

        return newAdmin;
    }

    /*
    metodo put para admins
    */

    public void Update(Administradore admin)
    {
        var existingAdmin = GetById(admin.Id);

        if (existingAdmin != null)
        {
            // actualizar solo los campos que se proporcionen en la solicitud
            if (existingAdmin.Nombre != null)
            {
                existingAdmin.Nombre = admin.Nombre;
            }
            if (existingAdmin.Apellido != null)
            {
                existingAdmin.Apellido = admin.Apellido;
            }
            if (existingAdmin.Correo != null)
            {
                existingAdmin.Correo = admin.Correo;
            }
            if (existingAdmin.Contraseña != null)
            {
                existingAdmin.Contraseña = admin.Contraseña;
            }
            if (existingAdmin.FechaRegistro != null)
            {
                existingAdmin.FechaRegistro = admin.FechaRegistro;
            }

            // guardar datos en la base de datos
            _context.SaveChanges();
        }
    }
}
