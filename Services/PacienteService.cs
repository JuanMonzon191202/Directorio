namespace CitasMedicasAPI.Services;

using CitasMedicasAPI.Data;
using CitasMedicasAPI.Data.CitasApiModels;


public class PacienteService
{
    private readonly DbdirectorioContext _context;

    public PacienteService(DbdirectorioContext context)
    {
        _context = context;

    }
    /* 
       metodos para manejar las solicitudes Get paciente
       /api/Paciente/getpaciente

       */
    public IEnumerable<Paciente> GetAll()
    {
        return _context.Pacientes.ToList();
    }
    /*
        metodos para manejar las solicitudes get by id pacientes
        /api/Paciente/getpaciente/{id}
        */
    public Paciente? GetById(int id)
    {
        return _context.Pacientes.Find(id);
    }
    /*
        metodo post para pacientes
        */
    public Paciente Create(Paciente newPaciente)
    {
        _context.Pacientes.Add(newPaciente);
        _context.SaveChanges();

        return newPaciente;
    }
    /*
       metodo put para pacientes
       */
    public void Update(Paciente paciente)
    {
        var existingPaciente = GetById(paciente.Id);

        if (existingPaciente is not null)
        {
            existingPaciente.Nombre = paciente.Nombre;
            existingPaciente.Apellido = paciente.Apellido;
            existingPaciente.Correo = paciente.Correo;
            existingPaciente.Contrasenia = paciente.Contrasenia;
            existingPaciente.Genero = paciente.Genero;
            existingPaciente.Telefono = paciente.Telefono;
            existingPaciente.Ciudad = paciente.Ciudad;
            existingPaciente.Pais = paciente.Pais;

            _context.SaveChanges();
        }
    }
}