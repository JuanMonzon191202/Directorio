using CitasMedicasAPI.Data.CitasApiModels;
using Microsoft.EntityFrameworkCore;

namespace CitasMedicasAPI.Data
{
    public class DbdirectorioContext : DbContext
    {
        public DbSet<Especialidade> Especialidades { get; set; } //
        public DbSet<Cita> Citas {get;set;} //

        public DbSet<Usuario> Usuarios { get; set; } //
        public DbSet<Paciente> Pacientes { get; set; } //
        public DbSet<Especialista> Especialistas { get; set; } //
        public DbSet<CentrosMedicosClinica> CentrosMedicosClinicas { get; set; } //
        public DbSet<GrupEspecialidade> GrupEspecialidades { get; set; } //
        public DbSet<RolesUsuario> RolesUsuarios { get; set; } //

        public DbdirectorioContext(DbContextOptions<DbdirectorioContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de relaciones

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.RolesUsuario)
                .WithMany()
                .HasForeignKey(u => u.IdRol)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Paciente>()
                .HasOne(p => p.Usuario)
                .WithMany()
                .HasForeignKey(p => p.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Especialista>()
                .HasOne(e => e.Usuario)
                .WithMany()
                .HasForeignKey(e => e.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Especialista>()
                .HasOne(e => e.GrupEspecialidade)
                .WithMany()
                .HasForeignKey(e => e.IdGupEspecialidad)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CentrosMedicosClinica>()
                .HasOne(c => c.Usuario)
                .WithMany()
                .HasForeignKey(c => c.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CentrosMedicosClinica>()
                .HasOne(c => c.GrupEspecialidade)
                .WithMany()
                .HasForeignKey(c => c.IdGupEspecialidad)
                .OnDelete(DeleteBehavior.Restrict);

            // Otras configuraciones y restricciones de modelo pueden agregarse aquí

            base.OnModelCreating(modelBuilder);
        }
    }
}
