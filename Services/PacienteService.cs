namespace CitasMedicasAPI.Services;

using System;
using CitasMedicasAPI.Data;
using CitasMedicasAPI.Data.CitasApiModels;
using Microsoft.EntityFrameworkCore;
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
        // return _context.Pacientes.Find(id);
        return _context.Pacientes.Include(p => p.Usuario).SingleOrDefault(p => p.Id == id);
    }

    public Paciente? GetPacienteByUsuarioId(int idUsuario)
    {
        var usuario = _context.Usuarios.SingleOrDefault(u => u.Id == idUsuario);

        if (usuario != null)
        {
            // Crea un nuevo Paciente y asigna los valores del Usuario
            var paciente = new Paciente
            {
                Id = usuario.Id,
                // Asigna otras propiedades del Paciente
                Genero = "Algun valor",
                // Asigna el IdUsuario
                IdUsuario = usuario.Id
            };

            return paciente;
        }

        return null;
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

        if (existingPaciente != null)
        {
            // Actualizar solo los campos que se proporcionaron en la solicitud PUT


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

            // Guardar los cambios en la base de datos
            _context.SaveChanges();
        }
    }
}
