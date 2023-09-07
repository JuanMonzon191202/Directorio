using Microsoft.AspNetCore.Mvc;
using CitasMedicasAPI.Data;
using CitasMedicasAPI.Data.CitasApiModels;


[Route("api/[controller]")]
[ApiController]



public class EspecialistasController : ControllerBase{
    // Métodos para manejar las operaciones relacionadas con especialistas
     private readonly DbdirectorioContext _context;

     public EspecialistasController(DbdirectorioContext context) {

        //referenciando el contexto 
        _context = context;

    } 
    // metodos para manejar las solicitudes get de especialistas
/*
 metodo para listar los especialistas con un get 
*/
    [HttpGet ("getEspecialista")]
    public IEnumerable<Especialista> Get2(){
        return _context.Especialistas.ToList();
    }

/*
metodo get by id para los especialistas
*/

    [HttpGet("getEspecialista/{id}")]
    public ActionResult<Especialista>GetById(int id){
        var especialistaFind = _context.Especialistas.Find(id);
        if (especialistaFind is null){
            return NotFound();
        }
        return especialistaFind;
    }
    //TODO delete, put, post

    

    
}
