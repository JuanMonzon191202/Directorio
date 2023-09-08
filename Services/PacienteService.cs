namespace CitasMedicasAPI.Services;

using CitasMedicasAPI.Data;
using CitasMedicasAPI.Data.CitasApiModels;
using Microsoft.IdentityModel.Tokens;

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
       */public void Update(Paciente paciente)
{
    var existingPaciente = GetById(paciente.Id);

    if (existingPaciente != null)
    {
        // Actualizar solo los campos que se proporcionaron en la solicitud PUT
        existingPaciente.IdRol = paciente.IdRol;

        if (paciente.Nombre != null)
        {
            existingPaciente.Nombre = paciente.Nombre;
        }

        if (paciente.Apellido != null)
        {
            existingPaciente.Apellido = paciente.Apellido;
        }

        if (paciente.Correo != null)
        {
            existingPaciente.Correo = paciente.Correo;
        }

        if (paciente.Contrasenia != null)
        {
            existingPaciente.Contrasenia = paciente.Contrasenia;
        }

        if (paciente.FechaNac != null)
        {
            existingPaciente.FechaNac = paciente.FechaNac;
        }

        if (paciente.Genero != null)
        {
            existingPaciente.Genero = paciente.Genero;
        }

        if (paciente.Telefono != null)
        {
            existingPaciente.Telefono = paciente.Telefono;
        }

        if (paciente.Ciudad != null)
        {
            existingPaciente.Ciudad = paciente.Ciudad;
        }

        if (paciente.Pais != null)
        {
            existingPaciente.Pais = paciente.Pais;
        }

        if (paciente.FechaRegistro != null)
        {
            existingPaciente.FechaRegistro = paciente.FechaRegistro;
        }

        if (paciente.Activo != null)
        {
            existingPaciente.Activo = paciente.Activo;
        }

        // Guardar los cambios en la base de datos
        _context.SaveChanges();
    }
}

}
