using System;
using Microsoft.EntityFrameworkCore;
using CitasMedicasAPI.Data.CitasApiModels;

namespace CitasMedicasAPI.Data
{
    public partial class DbdirectorioContext : DbContext
    {
        public DbdirectorioContext(DbContextOptions<DbdirectorioContext> options) : base(options)
        {
        }

        public virtual DbSet<Administradore> Administradores { get; set; }
        public virtual DbSet<CentrosMedicosClinica> CentrosMedicosClinicas { get; set; }
        public virtual DbSet<Cita> Citas { get; set; }
        public virtual DbSet<Especialidade> Especialidades { get; set; }
        public virtual DbSet<Especialista> Especialistas { get; set; }
        public virtual DbSet<GrupEspecialidade> EspecialistasEspecialidades { get; set; }
        public virtual DbSet<Notificacione> Notificaciones { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<RolesUsuario> RolesUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Directorio;Trusted_connection=true;Encrypt=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de relaciones
            modelBuilder.Entity<CentrosMedicosClinica>()
                .HasOne(cmc => cmc.IdGrupEspecialidadeNavigation)
                .WithMany(ese => ese.CentrosMedicosClinicas)
                .HasForeignKey(cmc => cmc.IdEspecialistaEspecialidad);

            modelBuilder.Entity<CentrosMedicosClinica>()
                .HasOne(cmc => cmc.IdResponsableNavigation)
                .WithMany(admin => admin.CentrosMedicosClinicas)
                .HasForeignKey(cmc => cmc.IdResponsable);

            modelBuilder.Entity<CentrosMedicosClinica>()
                .HasOne(cmc => cmc.IdRolNavigation)
                .WithMany(rol => rol.CentrosMedicosClinicas)
                .HasForeignKey(cmc => cmc.IdRol);

            modelBuilder.Entity<Administradore>()
                .HasMany(admin => admin.CentrosMedicosClinicas)
                .WithOne(cmc => cmc.IdResponsableNavigation)
                .HasForeignKey(cmc => cmc.IdResponsable);

            modelBuilder.Entity<Administradore>()
                .HasMany(admin => admin.Especialista)
                .WithOne(esp => esp.IdResponsableNavigation)
                .HasForeignKey(esp => esp.IdResponsable);

            modelBuilder.Entity<Cita>()
                .HasOne(cita => cita.IdCmcNavigation)
                .WithMany(cmc => cmc.Cita)
                .HasForeignKey(cita => cita.IdCmc);

            modelBuilder.Entity<Cita>()
                .HasOne(cita => cita.IdEspecialistaNavigation)
                .WithMany(esp => esp.Cita)
                .HasForeignKey(cita => cita.IdEspecialista);

            modelBuilder.Entity<Cita>()
                .HasOne(cita => cita.IdPacienteNavigation)
                .WithMany(pac => pac.Cita)
                .HasForeignKey(cita => cita.IdPaciente);

            modelBuilder.Entity<Notificacione>()
                .HasOne(notif => notif.IdCitaNavigation)
                .WithMany(cita => cita.Notificaciones)
                .HasForeignKey(notif => notif.IdCita);
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.IdRolNavigation)  // Nombre de la propiedad de navegación en Usuario
                .WithMany()  // No se necesita especificar la propiedad de navegación en RolesUsuario
                .HasForeignKey(u => u.IdRol)  // Clave foránea en Usuario que relaciona con Id en RolesUsuario
                .OnDelete(DeleteBehavior.Restrict);  // Puedes establecer el comportamiento de eliminación según tus necesidades
            
        }
    }
}
