namespace CitasMedicasAPI.Services;

using CitasMedicasAPI.Data;
using CitasMedicasAPI.Data.CitasApiModels;

public class RolesService
{

    private readonly DbdirectorioContext _context;

    public RolesService(DbdirectorioContext context)
    {
        _context = context;
    }

    public IEnumerable<RolesUsuario> GetAll()
    {
        return _context.RolesUsuarios.ToList();
    }

    public RolesUsuario? GetById(int id)
    {
        return _context.RolesUsuarios.Find(id);
    }

    public RolesUsuario Create(RolesUsuario newRol)
    {
        _context.RolesUsuarios.Add(newRol);
        _context.SaveChanges();

        return newRol;
    }

    public void Update(RolesUsuario rol)
    {
        var existingRol = GetById(rol.Id);

        if (existingRol != null)
        {

            if (rol.NombreRol != null)
            {

                existingRol.NombreRol = rol.NombreRol;
            }
            _context.SaveChanges();
        }


    }
}