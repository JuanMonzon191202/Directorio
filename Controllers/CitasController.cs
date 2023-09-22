// using Microsoft.AspNetCore.Mvc;
// using CitasMedicasAPI.Services;
// using CitasMedicasAPI.Data.CitasApiModels;
// using System.Runtime.CompilerServices;

// namespace CitasMedicasAPI.Controllers;

// [ApiController]
// [Route("api/[controller]")]
// public class CitasController : ControllerBase
// {
//     private readonly CitasService _service;

//     public CitasController(CitasService service)
//     {
//         _service = service;
//     }

//     [HttpGet("citas")]
//     public IEnumerable<Cita> Get()
//     {
//         return _service.GetAll();
//     }

//     [HttpGet("citas/{id}")]
//     public ActionResult<Cita> GetById(int id)
//     {
//         var citaFind = _service.GetById(id);

//         if (citaFind is null)
//         {
//             return NotFound();
//         }
//         return citaFind;
//     }

//     /*
//     buscar citas por Especualista o CMC

//     */

//     [HttpGet("porespecialista/{idEspecialista}")]
//     public IActionResult GetCitasPorEspecialista(int idEspecialista)
//     {
//         var citas = _service.GetCitasPorEspecialista(idEspecialista);

//         if (citas == null || !citas.Any())
//         {
//             return NotFound("No se encontraron citas para el especialista especificado.");
//         }

//         return Ok(citas);
//     }

//     [HttpGet("porcmc/{idCMC}")]
//     public IActionResult GetCitasPorCMC(int idCMC)
//     {
//         var citas = _service.GetCitasPorCMC(idCMC);

//         if (citas == null || !citas.Any())
//         {
//             return NotFound("No se encontraron citas para la CMC especificada.");
//         }

//         return Ok(citas);
//     }

//     [HttpPost("citas")]
//     public IActionResult Create(Cita cita)
//     {
//         var newCita = _service.Create(cita);
//         return CreatedAtAction(nameof(GetById), new { id = newCita.Id }, newCita);
//     }

//     [HttpPut("citas/{id}")]
//     public IActionResult Update(int id, Cita cita)
//     {
//         if (id != cita.Id)
//         {
//             return BadRequest("El ID proporcionado no coincide con el ID de la Cita.");
//         }
//         var citaToUpdate = _service.GetById(id);
//         if (citaToUpdate == null)
//         {
//             return NotFound($"Cita con ID {id} no encontrado.");
//         }
//         _service.Update(cita);

//         return NoContent();
//     }
// }
