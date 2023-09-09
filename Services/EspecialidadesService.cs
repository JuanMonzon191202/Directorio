namespace CitasMedicasAPI.Services;

using System.Runtime.Serialization;
using CitasMedicasAPI.Data;
using CitasMedicasAPI.Data.CitasApiModels;


public class EspecialidadesService{

    private readonly DbdirectorioContext _context;

    public EspecialidadesService(DbdirectorioContext context){

        _context = context;
    }
    /*
    metodo getAll para las especialidades

    */

    public IEnumerable<Especialidade>GetAll(){

        return _context.Especialidades.ToList();
    }

    /*
    metodo GetById solicitudes
    */

    public Especialidade? GetById(int id){
        return _context.Especialidades.Find(id);
    }

    /*
    metodo post para crear una nueva especialidad
    */

    public Especialidade Create(Especialidade newEspecialidade){

        _context.Especialidades.Add(newEspecialidade);
        _context.SaveChanges();

        return newEspecialidade;

    }

    /*
    Metodo put para editar las especialidades
    */
    public void Update(Especialidade especialidade){
        var existingEspecialidade = GetById(especialidade.Id);

        if (existingEspecialidade != null){
            // Actualizar solo los campos que se proporcionaron en la solicitud PUT
            if (especialidade.Nombre != null){
                existingEspecialidade.Nombre = especialidade.Nombre;
            }

            //guardar los cambios a la DB
            _context.SaveChanges();
        }
    }


}

