using Aplicacion;
using Dominio;
using Infraestructura;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configura el DbContext
builder.Services.AddSingleton<DbContexto>(); // Registra DbContexto como servicio

// Configura el repositorio
builder.Services.AddSingleton<PersonaRepositorio>(); //

// Configura el servicio
builder.Services.AddScoped<PersonaServicio>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
