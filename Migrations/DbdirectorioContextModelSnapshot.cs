﻿// <auto-generated />
using System;
using CitasMedicasAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CitasMedicasAPI.Migrations
{
    [DbContext(typeof(DbdirectorioContext))]
    partial class DbdirectorioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CitasMedicasAPI.Data.CitasApiModels.Administradore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contraseña")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Administradores");
                });

            modelBuilder.Entity("CitasMedicasAPI.Data.CitasApiModels.CentrosMedicosClinica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("CiudadCmc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorreoCmc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescripcionCmc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DireccionCmc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdEspecialistaEspecialidad")
                        .HasColumnType("int");

                    b.Property<int?>("IdResponsable")
                        .HasColumnType("int");

                    b.Property<int?>("IdRol")
                        .HasColumnType("int");

                    b.Property<string>("NombreCmc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreCompletoResponsable")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaisCmc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonalCountCmc")
                        .HasColumnType("int");

                    b.Property<string>("ResponsableCiudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResponsableCorreo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResponsableTelefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SitioWebCmc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonoCmc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdEspecialistaEspecialidad");

                    b.HasIndex("IdResponsable");

                    b.HasIndex("IdRol");

                    b.ToTable("CentrosMedicosClinicas");
                });

            modelBuilder.Entity("CitasMedicasAPI.Data.CitasApiModels.Cita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaCita")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan?>("HoraFin")
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("HoraInicio")
                        .HasColumnType("time");

                    b.Property<int?>("IdCmc")
                        .HasColumnType("int");

                    b.Property<int?>("IdEspecialista")
                        .HasColumnType("int");

                    b.Property<int?>("IdPaciente")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCmc");

                    b.HasIndex("IdEspecialista");

                    b.HasIndex("IdPaciente");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("CitasMedicasAPI.Data.CitasApiModels.Especialidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Especialidades");
                });

            modelBuilder.Entity("CitasMedicasAPI.Data.CitasApiModels.Especialista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contrasenia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaNac")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Genero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdEspecialidad")
                        .HasColumnType("int");

                    b.Property<int?>("IdEspecialidadNavigationId")
                        .HasColumnType("int");

                    b.Property<int?>("IdResponsable")
                        .HasColumnType("int");

                    b.Property<int?>("IdRol")
                        .HasColumnType("int");

                    b.Property<int?>("IdRolNavigationId")
                        .HasColumnType("int");

                    b.Property<string>("NombreCompleto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumCedula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdEspecialidadNavigationId");

                    b.HasIndex("IdResponsable");

                    b.HasIndex("IdRolNavigationId");

                    b.ToTable("Especialistas");
                });

            modelBuilder.Entity("CitasMedicasAPI.Data.CitasApiModels.EspecialistasEspecialidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("IdEspecialidad")
                        .HasColumnType("int");

                    b.Property<int?>("IdEspecialidadNavigationId")
                        .HasColumnType("int");

                    b.Property<int?>("IdEspecialista")
                        .HasColumnType("int");

                    b.Property<int?>("IdEspecialistaNavigationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdEspecialidadNavigationId");

                    b.HasIndex("IdEspecialistaNavigationId");

                    b.ToTable("EspecialistasEspecialidades");
                });

            modelBuilder.Entity("CitasMedicasAPI.Data.CitasApiModels.Notificacione", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contenido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaEnvio")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdCita")
                        .HasColumnType("int");

                    b.Property<bool?>("Leido")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdCita");

                    b.ToTable("Notificaciones");
                });

            modelBuilder.Entity("CitasMedicasAPI.Data.CitasApiModels.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contrasenia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaNac")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Genero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdRol")
                        .HasColumnType("int");

                    b.Property<int?>("IdRolNavigationId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdRolNavigationId");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("CitasMedicasAPI.Data.CitasApiModels.RolesUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NombreRol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RolesUsuarios");
                });

            modelBuilder.Entity("CitasMedicasAPI.Data.CitasApiModels.CentrosMedicosClinica", b =>
                {
                    b.HasOne("CitasMedicasAPI.Data.CitasApiModels.EspecialistasEspecialidade", "IdEspecialistaEspecialidadNavigation")
                        .WithMany("CentrosMedicosClinicas")
                        .HasForeignKey("IdEspecialistaEspecialidad");

                    b.HasOne("CitasMedicasAPI.Data.CitasApiModels.Administradore", "IdResponsableNavigation")
                        .WithMany("CentrosMedicosClinicas")
                        .HasForeignKey("IdResponsable");

                    b.HasOne("CitasMedicasAPI.Data.CitasApiModels.RolesUsuario", "IdRolNavigation")
                        .WithMany("CentrosMedicosClinicas")
                        .HasForeignKey("IdRol");

                    b.Navigation("IdEspecialistaEspecialidadNavigation");

                    b.Navigation("IdResponsableNavigation");

                    b.Navigation("IdRolNavigation");
                });

            modelBuilder.Entity("CitasMedicasAPI.Data.CitasApiModels.Cita", b =>
                {
                    b.HasOne("CitasMedicasAPI.Data.CitasApiModels.CentrosMedicosClinica", "IdCmcNavigation")
                        .WithMany("Cita")
                        .HasForeignKey("IdCmc");

                    b.HasOne("CitasMedicasAPI.Data.CitasApiModels.Especialista", "IdEspecialistaNavigation")
                        .WithMany("Cita")
                        .HasForeignKey("IdEspecialista");

                    b.HasOne("CitasMedicasAPI.Data.CitasApiModels.Paciente", "IdPacienteNavigation")
                        .WithMany("Cita")
                        .HasForeignKey("IdPaciente");

                    b.Navigation("IdCmcNavigation");

                    b.Navigation("IdEspecialistaNavigation");

                    b.Navigation("IdPacienteNavigation");
                });

            modelBuilder.Entity("CitasMedicasAPI.Data.CitasApiModels.Especialista", b =>
                {
                    b.HasOne("CitasMedicasAPI.Data.CitasApiModels.Especialidade", "IdEspecialidadNavigation")
                        .WithMany("Especialista")
                        .HasForeignKey("IdEspecialidadNavigationId");

                    b.HasOne("CitasMedicasAPI.Data.CitasApiModels.Administradore", "IdResponsableNavigation")
                        .WithMany("Especialista")
                        .HasForeignKey("IdResponsable");

                    b.HasOne("CitasMedicasAPI.Data.CitasApiModels.RolesUsuario", "IdRolNavigation")
                        .WithMany("Especialista")
                        .HasForeignKey("IdRolNavigationId");

                    b.Navigation("IdEspecialidadNavigation");

                    b.Navigation("IdResponsableNavigation");

                    b.Navigation("IdRolNavigation");
                });

            modelBuilder.Entity("CitasMedicasAPI.Data.CitasApiModels.EspecialistasEspecialidade", b =>
                {
                    b.HasOne("CitasMedicasAPI.Data.CitasApiModels.Especialidade", "IdEspecialidadNavigation")
                        .WithMany("EspecialistasEspecialidades")
                        .HasForeignKey("IdEspecialidadNavigationId");

                    b.HasOne("CitasMedicasAPI.Data.CitasApiModels.Especialista", "IdEspecialistaNavigation")
                        .WithMany("EspecialistasEspecialidades")
                        .HasForeignKey("IdEspecialistaNavigationId");

                    b.Navigation("IdEspecialidadNavigation");

                    b.Navigation("IdEspecialistaNavigation");
                });

            modelBuilder.Entity("CitasMedicasAPI.Data.CitasApiModels.Notificacione", b =>
                {
                    b.HasOne("CitasMedicasAPI.Data.CitasApiModels.Cita", "IdCitaNavigation")
                        .WithMany("Notificaciones")
                        .HasForeignKey("IdCita");

                    b.Navigation("IdCitaNavigation");
                });

            modelBuilder.Entity("CitasMedicasAPI.Data.CitasApiModels.Paciente", b =>
                {
                    b.HasOne("CitasMedicasAPI.Data.CitasApiModels.RolesUsuario", "IdRolNavigation")
                        .WithMany("Pacientes")
                        .HasForeignKey("IdRolNavigationId");

                    b.Navigation("IdRolNavigation");
                });

            modelBuilder.Entity("CitasMedicasAPI.Data.CitasApiModels.Administradore", b =>
                {
                    b.Navigation("CentrosMedicosClinicas");

                    b.Navigation("Especialista");
                });

            modelBuilder.Entity("CitasMedicasAPI.Data.CitasApiModels.CentrosMedicosClinica", b =>
                {
                    b.Navigation("Cita");
                });

            modelBuilder.Entity("CitasMedicasAPI.Data.CitasApiModels.Cita", b =>
                {
                    b.Navigation("Notificaciones");
                });

            modelBuilder.Entity("CitasMedicasAPI.Data.CitasApiModels.Especialidade", b =>
                {
                    b.Navigation("Especialista");

                    b.Navigation("EspecialistasEspecialidades");
                });

            modelBuilder.Entity("CitasMedicasAPI.Data.CitasApiModels.Especialista", b =>
                {
                    b.Navigation("Cita");

                    b.Navigation("EspecialistasEspecialidades");
                });

            modelBuilder.Entity("CitasMedicasAPI.Data.CitasApiModels.EspecialistasEspecialidade", b =>
                {
                    b.Navigation("CentrosMedicosClinicas");
                });

            modelBuilder.Entity("CitasMedicasAPI.Data.CitasApiModels.Paciente", b =>
                {
                    b.Navigation("Cita");
                });

            modelBuilder.Entity("CitasMedicasAPI.Data.CitasApiModels.RolesUsuario", b =>
                {
                    b.Navigation("CentrosMedicosClinicas");

                    b.Navigation("Especialista");

                    b.Navigation("Pacientes");
                });
#pragma warning restore 612, 618
        }
    }
}