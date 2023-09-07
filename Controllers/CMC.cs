using Microsoft.AspNetCore.Mvc;
using CitasMedicasAPI.Data;
using CitasMedicasAPI.Data.CitasApiModels;


[Route("api/[controller]")]
[ApiController]
public class CMCController : ControllerBase
{
    // Métodos para manejar las operaciones relacionadas con especialistas
    private readonly DbdirectorioContext _context;

    public CMCController(DbdirectorioContext context)
    {


        _context = context;
    }

    /* 
   metodo para listar los CMC [centros medicos o Clinicas] con un get 
   */

    [HttpGet("getCMC")]
    public IEnumerable<CentrosMedicosClinica> Get()
    {
        return _context.CentrosMedicosClinicas.ToList();
    }

}