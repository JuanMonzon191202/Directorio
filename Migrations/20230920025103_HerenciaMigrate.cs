using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CitasMedicasAPI.Migrations
{
    /// <inheritdoc />
    public partial class HerenciaMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolesUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRol = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesUsuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRol = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especialistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdResponsable = table.Column<int>(type: "int", nullable: true),
                    IdEspecialistaEspecialidad = table.Column<int>(type: "int", nullable: true),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumCedula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EspecialidadeId = table.Column<int>(type: "int", nullable: true),
                    RolesUsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialistas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Especialistas_Administradores_IdResponsable",
                        column: x => x.IdResponsable,
                        principalTable: "Administradores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Especialistas_Especialidades_EspecialidadeId",
                        column: x => x.EspecialidadeId,
                        principalTable: "Especialidades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Especialistas_RolesUsuarios_RolesUsuarioId",
                        column: x => x.RolesUsuarioId,
                        principalTable: "RolesUsuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNac = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdRolNavigationId = table.Column<int>(type: "int", nullable: true),
                    IdUsuarioNavigationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_RolesUsuarios_IdRolNavigationId",
                        column: x => x.IdRolNavigationId,
                        principalTable: "RolesUsuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pacientes_Usuarios_IdUsuarioNavigationId",
                        column: x => x.IdUsuarioNavigationId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CentrosMedicosClinicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRol = table.Column<int>(type: "int", nullable: true),
                    IdResponsable = table.Column<int>(type: "int", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: true),
                    IdEspecialistaEspecialidad = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalCount = table.Column<int>(type: "int", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SitioWeb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUsuarioNavigationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentrosMedicosClinicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CentrosMedicosClinicas_Administradores_IdResponsable",
                        column: x => x.IdResponsable,
                        principalTable: "Administradores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CentrosMedicosClinicas_RolesUsuarios_IdRol",
                        column: x => x.IdRol,
                        principalTable: "RolesUsuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CentrosMedicosClinicas_Usuarios_IdUsuarioNavigationId",
                        column: x => x.IdUsuarioNavigationId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaciente = table.Column<int>(type: "int", nullable: true),
                    IdEspecialista = table.Column<int>(type: "int", nullable: true),
                    IdCmc = table.Column<int>(type: "int", nullable: true),
                    FechaCita = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraInicio = table.Column<TimeSpan>(type: "time", nullable: true),
                    HoraFin = table.Column<TimeSpan>(type: "time", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eliminado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Citas_CentrosMedicosClinicas_IdCmc",
                        column: x => x.IdCmc,
                        principalTable: "CentrosMedicosClinicas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Citas_Especialistas_IdEspecialista",
                        column: x => x.IdEspecialista,
                        principalTable: "Especialistas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Citas_Pacientes_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EspecialistasEspecialidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEspecialista = table.Column<int>(type: "int", nullable: true),
                    IdCMC = table.Column<int>(type: "int", nullable: true),
                    IdEspecialidad = table.Column<int>(type: "int", nullable: true),
                    IdEspecialidadNavigationId = table.Column<int>(type: "int", nullable: true),
                    IdEspecialistaNavigationId = table.Column<int>(type: "int", nullable: true),
                    idCentrosMedicosClinicaNavigationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecialistasEspecialidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EspecialistasEspecialidades_CentrosMedicosClinicas_idCentrosMedicosClinicaNavigationId",
                        column: x => x.idCentrosMedicosClinicaNavigationId,
                        principalTable: "CentrosMedicosClinicas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EspecialistasEspecialidades_Especialidades_IdEspecialidadNavigationId",
                        column: x => x.IdEspecialidadNavigationId,
                        principalTable: "Especialidades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EspecialistasEspecialidades_Especialistas_IdEspecialistaNavigationId",
                        column: x => x.IdEspecialistaNavigationId,
                        principalTable: "Especialistas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCita = table.Column<int>(type: "int", nullable: true),
                    Contenido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Leido = table.Column<bool>(type: "bit", nullable: true),
                    FechaEnvio = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notificaciones_Citas_IdCita",
                        column: x => x.IdCita,
                        principalTable: "Citas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CentrosMedicosClinicas_IdEspecialistaEspecialidad",
                table: "CentrosMedicosClinicas",
                column: "IdEspecialistaEspecialidad");

            migrationBuilder.CreateIndex(
                name: "IX_CentrosMedicosClinicas_IdResponsable",
                table: "CentrosMedicosClinicas",
                column: "IdResponsable");

            migrationBuilder.CreateIndex(
                name: "IX_CentrosMedicosClinicas_IdRol",
                table: "CentrosMedicosClinicas",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_CentrosMedicosClinicas_IdUsuarioNavigationId",
                table: "CentrosMedicosClinicas",
                column: "IdUsuarioNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_IdCmc",
                table: "Citas",
                column: "IdCmc");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_IdEspecialista",
                table: "Citas",
                column: "IdEspecialista");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_IdPaciente",
                table: "Citas",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Especialistas_EspecialidadeId",
                table: "Especialistas",
                column: "EspecialidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Especialistas_IdResponsable",
                table: "Especialistas",
                column: "IdResponsable");

            migrationBuilder.CreateIndex(
                name: "IX_Especialistas_RolesUsuarioId",
                table: "Especialistas",
                column: "RolesUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_EspecialistasEspecialidades_idCentrosMedicosClinicaNavigationId",
                table: "EspecialistasEspecialidades",
                column: "idCentrosMedicosClinicaNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_EspecialistasEspecialidades_IdEspecialidadNavigationId",
                table: "EspecialistasEspecialidades",
                column: "IdEspecialidadNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_EspecialistasEspecialidades_IdEspecialistaNavigationId",
                table: "EspecialistasEspecialidades",
                column: "IdEspecialistaNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificaciones_IdCita",
                table: "Notificaciones",
                column: "IdCita");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_IdRolNavigationId",
                table: "Pacientes",
                column: "IdRolNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_IdUsuarioNavigationId",
                table: "Pacientes",
                column: "IdUsuarioNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CentrosMedicosClinicas_EspecialistasEspecialidades_IdEspecialistaEspecialidad",
                table: "CentrosMedicosClinicas",
                column: "IdEspecialistaEspecialidad",
                principalTable: "EspecialistasEspecialidades",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CentrosMedicosClinicas_Administradores_IdResponsable",
                table: "CentrosMedicosClinicas");

            migrationBuilder.DropForeignKey(
                name: "FK_Especialistas_Administradores_IdResponsable",
                table: "Especialistas");

            migrationBuilder.DropForeignKey(
                name: "FK_CentrosMedicosClinicas_EspecialistasEspecialidades_IdEspecialistaEspecialidad",
                table: "CentrosMedicosClinicas");

            migrationBuilder.DropTable(
                name: "Notificaciones");

            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "EspecialistasEspecialidades");

            migrationBuilder.DropTable(
                name: "CentrosMedicosClinicas");

            migrationBuilder.DropTable(
                name: "Especialistas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "RolesUsuarios");
        }
    }
}
