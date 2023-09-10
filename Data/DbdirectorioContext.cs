using System;
using System.Collections.Generic;
using CitasMedicasAPI.Data.CitasApiModels;
using Microsoft.EntityFrameworkCore;

namespace CitasMedicasAPI.Data;

public partial class DbdirectorioContext : DbContext
{
    public DbdirectorioContext()
    {
    }

    public DbdirectorioContext(DbContextOptions<DbdirectorioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administradore> Administradores { get; set; }

    public virtual DbSet<CentrosMedicosClinica> CentrosMedicosClinicas { get; set; }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<Especialidade> Especialidades { get; set; }

    public virtual DbSet<Especialista> Especialistas { get; set; }

    public virtual DbSet<EspecialistasEspecialidade> EspecialistasEspecialidades { get; set; }

    public virtual DbSet<Notificacione> Notificaciones { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<RolesUsuario> RolesUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=DBDirectorio;Trusted_connection=true;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administradore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Administ__3213E83FE9EADAA5");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<CentrosMedicosClinica>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CentrosM__3213E83F04A61C81");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.CiudadCmc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ciudadCMC");
            entity.Property(e => e.CorreoCmc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correoCMC");
            entity.Property(e => e.DescripcionCmc)
                .HasColumnType("text")
                .HasColumnName("descripcionCMC");
            entity.Property(e => e.DireccionCmc)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("direccionCMC");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdResponsable).HasColumnName("Id_responsable");
            entity.Property(e => e.IdRol).HasColumnName("Id_rol");
            entity.Property(e => e.NombreCmc)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nombreCMC");
            entity.Property(e => e.NombreCompletoResponsable)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreCompletoResponsable");
            entity.Property(e => e.PaisCmc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("paisCMC");
            entity.Property(e => e.PersonalCountCmc).HasColumnName("personalCountCMC");
            entity.Property(e => e.ResponsableCiudad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("responsableCiudad");
            entity.Property(e => e.ResponsableCorreo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("responsableCorreo");
            entity.Property(e => e.ResponsableTelefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("responsableTelefono");
            entity.Property(e => e.SitioWebCmc)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("sitioWebCMC");
            entity.Property(e => e.TelefonoCmc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telefonoCMC");

            entity.HasOne(d => d.IdResponsableNavigation).WithMany(p => p.CentrosMedicosClinicas)
                .HasForeignKey(d => d.IdResponsable)
                .HasConstraintName("FK_CentrosMedicosClinicas_Administradores");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.CentrosMedicosClinicas)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK_CentrosMedicosClinicas_RolesUsuario");
        });

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Citas__3213E83F61694A81");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaCita)
                .HasColumnType("date")
                .HasColumnName("fechaCita");
            entity.Property(e => e.HoraFin).HasColumnName("horaFin");
            entity.Property(e => e.HoraInicio).HasColumnName("horaInicio");
            entity.Property(e => e.IdCmc).HasColumnName("id_CMC");
            entity.Property(e => e.IdEspecialista).HasColumnName("id_Especialista");
            entity.Property(e => e.IdPaciente).HasColumnName("id_Paciente");

            entity.HasOne(d => d.IdCmcNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdCmc)
                .HasConstraintName("FK_Citas_CentrosMedicosClinicas");

            entity.HasOne(d => d.IdEspecialistaNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdEspecialista)
                .HasConstraintName("FK_Citas_Especialistas");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdPaciente)
                .HasConstraintName("FK_Citas_Pacientes");
        });

        modelBuilder.Entity<Especialidade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Especial__3213E83F78F4A05C");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Especialista>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Especial__3213E83F217A3F97");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ciudad");
            entity.Property(e => e.Contrasenia)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("contrasenia");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.FechaNac)
                .HasColumnType("date")
                .HasColumnName("fechaNac");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Genero)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("genero");
            entity.Property(e => e.IdEspecialidad).HasColumnName("Id_especialidad");
            entity.Property(e => e.IdResponsable).HasColumnName("Id_responsable");
            entity.Property(e => e.IdRol).HasColumnName("Id_rol");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreCompleto");
            entity.Property(e => e.NumCedula)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numCedula");
            entity.Property(e => e.Pais)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pais");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdEspecialidadNavigation).WithMany(p => p.Especialista)
                .HasForeignKey(d => d.IdEspecialidad)
                .HasConstraintName("FK_Especialistas_Especialidades");

            entity.HasOne(d => d.IdResponsableNavigation).WithMany(p => p.Especialista)
                .HasForeignKey(d => d.IdResponsable)
                .HasConstraintName("FK_Especialistas_Administradores");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Especialista)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK_Especialistas_RolesUsuario");
        });

        modelBuilder.Entity<EspecialistasEspecialidade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Especial__3214EC072F3B0B55");

            entity.HasOne(d => d.IdEspecialidadNavigation).WithMany(p => p.EspecialistasEspecialidades)
                .HasForeignKey(d => d.IdEspecialidad)
                .HasConstraintName("FK__Especiali__IdEsp__10566F31");

            entity.HasOne(d => d.IdEspecialistaNavigation).WithMany(p => p.EspecialistasEspecialidades)
                .HasForeignKey(d => d.IdEspecialista)
                .HasConstraintName("FK__Especiali__IdEsp__0F624AF8");
        });

        modelBuilder.Entity<Notificacione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notifica__3213E83FB2F19EB2");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contenido)
                .HasColumnType("text")
                .HasColumnName("contenido");
            entity.Property(e => e.FechaEnvio)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaEnvio");
            entity.Property(e => e.IdCita).HasColumnName("id_cita");
            entity.Property(e => e.Leido).HasColumnName("leido");

            entity.HasOne(d => d.IdCitaNavigation).WithMany(p => p.Notificaciones)
                .HasForeignKey(d => d.IdCita)
                .HasConstraintName("FK_Notificaciones_Citas");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Paciente__3214EC07030D29DB");

            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contrasenia)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("contrasenia");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.FechaNac)
                .HasColumnType("date")
                .HasColumnName("fechaNac");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Genero)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IdRol).HasColumnName("Id_rol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Pais)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK_Pacientes_RolesUsuario");
        });

        modelBuilder.Entity<RolesUsuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RolesUsu__3214EC07A03C4CAF");

            entity.ToTable("RolesUsuario");

            entity.Property(e => e.NombreRol)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombreRol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
