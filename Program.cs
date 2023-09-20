using CitasMedicasAPI.Data;
using CitasMedicasAPI.Data.CitasApiModels;
using CitasMedicasAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DBcontext
builder.Services.AddSqlServer<DbdirectorioContext>(builder.Configuration.GetConnectionString("CitasConnetion"));

//inyectar servicio Paciente
builder.Services.AddScoped<PacienteService>();
//inyectar servicio Especialistas
builder.Services.AddScoped<EspecialistaService>();
// inyectar servicio CMC
builder.Services.AddScoped<CMCService>();
//TODO
//inyectar servicio administradores
// builder.Services.AddScoped<AdminService>();
// inyectar servicio Especialidades
builder.Services.AddScoped<EspecialidadesService>();
// inyectar servicio de Cita
builder.Services.AddScoped<CitasService>();
// inyectar servicio de Roles
builder.Services.AddScoped<RolesService>();
//inyectar servicio de usuarios
builder.Services.AddScoped<UsuarioService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
