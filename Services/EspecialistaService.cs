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

    // public IEnumerable<Especialista> GetEspecialistasPorEspecialidad(int idEspecialidad)
    // {
    //     return _context.Especialistas.Where(e => e.IdEspecialidad == idEspecialidad).ToList();
    // }

    // public IEnumerable<Especialista> GetEspecialistasByEspecialidad(int especialidadId)
    // {
    //     // Utiliza LINQ para filtrar los especialistas por el ID de la especialidad
    //     var especialistas = _context.Especialistas
    //         .Where(
    //             e => e.GrupEspecialidades.Any(es => es.IdEspecialidad == especialidadId)
    //         )
    //         .ToList();

    //     return especialistas;
    // }

//TODO la tabla de las CMC no tienen especialidades con este metodo ya podra obtener tanto los especialistas como las CMC


    public IEnumerable<object> GetEspecialistasYCMCPorEspecialidad(int especialidadId)
    {
        var query =
        from ee in _context.GrupEspecialidades
        join e in _context.Especialistas on ee.IdEspecialista equals e.Id
        join cmc in _context.CentrosMedicosClinicas on ee.IdEspecialista equals cmc.IdResponsable
        where ee.IdEspecialidad == especialidadId
        select new { Especialista = e, CentroMedicoClinica = cmc };

return query.ToList();
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

        if (existingEspecialista != null)
        {
            existingEspecialista.Id = especialista.Id;
            existingEspecialista.Correo = especialista.Correo;
            existingEspecialista.Direccion = especialista.Direccion;
            existingEspecialista.Telefono = especialista.Telefono;
            existingEspecialista.Ciudad = especialista.Ciudad;
            existingEspecialista.Pais = especialista.Pais;
            existingEspecialista.NumCedula = especialista.NumCedula;

            _context.SaveChanges();
        }
    }
}
