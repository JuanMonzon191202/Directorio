using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CitasMedicasAPI.Migrations
{
    /// <inheritdoc />
    public partial class NuevaMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    NombreRol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
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
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_RolesUsuarios_IdRol",
                        column: x => x.IdRol,
                        principalTable: "RolesUsuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNac = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    IdGupEspecialidad = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalCount = table.Column<int>(type: "int", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SitioWeb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrupEspecialidadeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentrosMedicosClinicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CentrosMedicosClinicas_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Especialistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: true),
                    IdResponsable = table.Column<int>(type: "int", nullable: true),
                    IdGupEspecialidad = table.Column<int>(type: "int", nullable: true),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumCedula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialistas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Especialistas_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GrupEspecialidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEspecialista = table.Column<int>(type: "int", nullable: true),
                    IdCMC = table.Column<int>(type: "int", nullable: true),
                    IdEspecialidad = table.Column<int>(type: "int", nullable: false),
                    IdEspecialidadNavigationId = table.Column<int>(type: "int", nullable: true),
                    IdEspecialistaNavigationId = table.Column<int>(type: "int", nullable: true),
                    idCentrosMedicosClinicaNavigationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupEspecialidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrupEspecialidades_CentrosMedicosClinicas_idCentrosMedicosClinicaNavigationId",
                        column: x => x.idCentrosMedicosClinicaNavigationId,
                        principalTable: "CentrosMedicosClinicas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GrupEspecialidades_Especialidades_IdEspecialidadNavigationId",
                        column: x => x.IdEspecialidadNavigationId,
                        principalTable: "Especialidades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GrupEspecialidades_Especialistas_IdEspecialistaNavigationId",
                        column: x => x.IdEspecialistaNavigationId,
                        principalTable: "Especialistas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CentrosMedicosClinicas_GrupEspecialidadeId",
                table: "CentrosMedicosClinicas",
                column: "GrupEspecialidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_CentrosMedicosClinicas_IdGupEspecialidad",
                table: "CentrosMedicosClinicas",
                column: "IdGupEspecialidad");

            migrationBuilder.CreateIndex(
                name: "IX_CentrosMedicosClinicas_IdUsuario",
                table: "CentrosMedicosClinicas",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Especialistas_IdGupEspecialidad",
                table: "Especialistas",
                column: "IdGupEspecialidad");

            migrationBuilder.CreateIndex(
                name: "IX_Especialistas_IdUsuario",
                table: "Especialistas",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_GrupEspecialidades_idCentrosMedicosClinicaNavigationId",
                table: "GrupEspecialidades",
                column: "idCentrosMedicosClinicaNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_GrupEspecialidades_IdEspecialidadNavigationId",
                table: "GrupEspecialidades",
                column: "IdEspecialidadNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_GrupEspecialidades_IdEspecialistaNavigationId",
                table: "GrupEspecialidades",
                column: "IdEspecialistaNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_IdUsuario",
                table: "Pacientes",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdRol",
                table: "Usuarios",
                column: "IdRol");

            migrationBuilder.AddForeignKey(
                name: "FK_CentrosMedicosClinicas_GrupEspecialidades_GrupEspecialidadeId",
                table: "CentrosMedicosClinicas",
                column: "GrupEspecialidadeId",
                principalTable: "GrupEspecialidades",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CentrosMedicosClinicas_GrupEspecialidades_IdGupEspecialidad",
                table: "CentrosMedicosClinicas",
                column: "IdGupEspecialidad",
                principalTable: "GrupEspecialidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Especialistas_GrupEspecialidades_IdGupEspecialidad",
                table: "Especialistas",
                column: "IdGupEspecialidad",
                principalTable: "GrupEspecialidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CentrosMedicosClinicas_GrupEspecialidades_GrupEspecialidadeId",
                table: "CentrosMedicosClinicas");

            migrationBuilder.DropForeignKey(
                name: "FK_CentrosMedicosClinicas_GrupEspecialidades_IdGupEspecialidad",
                table: "CentrosMedicosClinicas");

            migrationBuilder.DropForeignKey(
                name: "FK_Especialistas_GrupEspecialidades_IdGupEspecialidad",
                table: "Especialistas");

            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "GrupEspecialidades");

            migrationBuilder.DropTable(
                name: "CentrosMedicosClinicas");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "Especialistas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "RolesUsuarios");
        }
    }
}
