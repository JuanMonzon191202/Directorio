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
            if (cmc.IdEspecialistaEspecialidad != null){

                existingCMC.IdEspecialistaEspecialidad = cmc.IdEspecialistaEspecialidad;
            }
            
            _context.SaveChanges();
        }
    }
}
