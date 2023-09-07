namespace CitasMedicasAPI.Services;

using CitasMedicasAPI.Data;
using CitasMedicasAPI.Data.CitasApiModels;

public class EspecialistaService
{


    private readonly DbdirectorioContext _context;


    public EspecialistaService(DbdirectorioContext context)
    {
        _context = context;

    }

    public IEnumerable<Especialista> GetAll()
    {
        return _context.Especialistas.ToList();
    }

    public Especialista? GetById(int id)
    {
        return _context.Especialistas.Find(id);
    }

    public Especialista Create(Especialista newEspecialista)
    {
        _context.Especialistas.Add(newEspecialista);
        _context.SaveChanges();

        return newEspecialista;
    }

    public void Update(Especialista especialista)
    {

        var existingEspecialista = GetById(especialista.Id);

        if (existingEspecialista is null)
        {
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
        }




    }
}