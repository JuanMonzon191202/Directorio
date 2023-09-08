namespace CitasMedicasAPI.Services;
using CitasMedicasAPI.Data;
using CitasMedicasAPI.Data.CitasApiModels;

public class CMCService
{
    private readonly DbdirectorioContext _context;

    public CMCService(DbdirectorioContext context)
    {
        _context = context;
    }

    /*
    metodo get all para CMC
     */
    public IEnumerable<CentrosMedicosClinica> GetAll()
    {
        return _context.CentrosMedicosClinicas.ToList();
    }

    /*
    metodo getbyid para CMC
    */
    public CentrosMedicosClinica? GetById(int id)
    {
        return _context.CentrosMedicosClinicas.Find(id);
    }

    /*
    metodo create para CMC
    */
    public CentrosMedicosClinica Create(CentrosMedicosClinica newCMC)
    {
        _context.CentrosMedicosClinicas.Add(newCMC);
        _context.SaveChanges();

        return newCMC;
    }

    /*
    metodo UpDate para las CMC
    */
    public void Update(CentrosMedicosClinica cmc)
    {
        var existingCMC = GetById(cmc.Id);

        if (existingCMC != null)
        {
            // Actualizar solo los campos que se proporcionaron en la solicitud PUT
            if (cmc.IdRol.HasValue)
            {
                existingCMC.IdRol = cmc.IdRol.Value;
            }

            if (cmc.IdResponsable.HasValue)
            {
                existingCMC.IdResponsable = cmc.IdResponsable.Value;
            }

            if (cmc.NombreCompletoResponsable != null)
            {
                existingCMC.NombreCompletoResponsable = cmc.NombreCompletoResponsable;
            }

            if (cmc.ResponsableCorreo != null)
            {
                existingCMC.ResponsableCorreo = cmc.ResponsableCorreo;
            }

            if (cmc.ResponsableTelefono != null)
            {
                existingCMC.ResponsableTelefono = cmc.ResponsableTelefono;
            }

            if (cmc.ResponsableCiudad != null)
            {
                existingCMC.ResponsableCiudad = cmc.ResponsableCiudad;
            }

            if (cmc.NombreCmc != null)
            {
                existingCMC.NombreCmc = cmc.NombreCmc;
            }

            if (cmc.DireccionCmc != null)
            {
                existingCMC.DireccionCmc = cmc.DireccionCmc;
            }

            if (cmc.PersonalCountCmc.HasValue)
            {
                existingCMC.PersonalCountCmc = cmc.PersonalCountCmc.Value;
            }

            if (cmc.CiudadCmc != null)
            {
                existingCMC.CiudadCmc = cmc.CiudadCmc;
            }

            if (cmc.PaisCmc != null)
            {
                existingCMC.PaisCmc = cmc.PaisCmc;
            }

            if (cmc.TelefonoCmc != null)
            {
                existingCMC.TelefonoCmc = cmc.TelefonoCmc;
            }

            if (cmc.CorreoCmc != null)
            {
                existingCMC.CorreoCmc = cmc.CorreoCmc;
            }

            if (cmc.SitioWebCmc != null)
            {
                existingCMC.SitioWebCmc = cmc.SitioWebCmc;
            }

            if (cmc.DescripcionCmc != null)
            {
                existingCMC.DescripcionCmc = cmc.DescripcionCmc;
            }

            if (cmc.FechaRegistro != null)
            {
                existingCMC.FechaRegistro = cmc.FechaRegistro;
            }

            if (cmc.Activo.HasValue)
            {
                existingCMC.Activo = cmc.Activo.Value;
            }

            _context.SaveChanges();
        }
    }
}
