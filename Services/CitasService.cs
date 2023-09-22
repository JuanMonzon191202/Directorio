// namespace CitasMedicasAPI.Services;

// using CitasMedicasAPI.Data;
// using CitasMedicasAPI.Data.CitasApiModels;

// public class CitasService{

//     private readonly DbdirectorioContext _context;

//     public CitasService (DbdirectorioContext context){
//         _context = context;
//     }

//     public IEnumerable<Cita> GetAll(){
//         return _context.Citas.ToList();
//     }

//     public Cita? GetById(int id){
//         return _context.Citas.Find(id);
//     }
//     /*
//     citas por especialista o CMC
//     */
//     public IEnumerable<Cita> GetCitasPorEspecialista(int idEspecialista)
//     {
//         return _context.Citas.Where(c => c.IdEspecialista == idEspecialista).ToList();
//     }

//     public IEnumerable<Cita> GetCitasPorCMC(int idCMC)
//     {
//         return _context.Citas.Where(c => c.IdCmc == idCMC).ToList();
//     }


//     public Cita Create(Cita newCita){

//         _context.Citas.Add(newCita);
//         _context.SaveChanges();

//         return newCita;
//     }

//     public void Update(Cita cita){
//         var existingCita = GetById(cita.Id);

//         if (cita != null){
            
//             if (cita.IdEspecialista != null){
//                 existingCita.IdEspecialista = cita.IdEspecialista;
//             }
//             if (cita.IdCmc != null){
//                 existingCita.IdCmc = cita.IdCmc;
//             }
//             if (cita.IdPaciente != null){
//                 existingCita.IdPaciente = cita.IdPaciente;
//             }
//             if (cita.FechaCita != null){
//                 existingCita.FechaCita = cita.FechaCita;
//             }
//             if (cita.HoraInicio != null){
//                 existingCita.HoraInicio = cita.HoraInicio;
//             }
//             if ( cita.HoraFin != null){
//                 existingCita.HoraFin = cita.HoraFin;
//             }
//             if (cita.Estado != null){
//                 existingCita.Estado = cita.Estado;
//             }
//         }
//     }
// }