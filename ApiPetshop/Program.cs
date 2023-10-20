using Microsoft.EntityFrameworkCore;
using System.Reflection;


using Persistence;
using ApiPetshop.Extensions;
using AspNetCoreRateLimit;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* SERVICIOS */

// Asignar la conexión a la bd:
builder.Services.AddDbContext<PetshopContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("MySqlConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.ConfigureCors(); // Inyectar el servicio de politicas de CORS

builder.Services.AddApplicationServices(); // Inyectar la Unidad de trabajo.

builder.Services.AddAutoMapper(Assembly.GetEntryAssembly()); // para mapear objetos de una clase a otra automáticamente pa los Dtos.

builder.Services.ConfigureRateLimiting(); // Inyectar rateLimit

builder.Services.ConfigureApiVersioning(); // Inyectar Versionamiento

//  Configurar el comportamiento del formateo de respuestas
builder.Services.AddControllers(options => 
{
    options.RespectBrowserAcceptHeader = true; // Tomar y basarse en cabecera "Accept" enviada por el navegador del cliente en las solicitudes HTTP
    options.ReturnHttpNotAcceptable = true; // Sino se especifica un Accept en la cabecera de la petición, esto devolverá una respuesta HTTP "406 Not Acceptable" en lugar de intentar responder con un formato no deseado.
})/* .AddXmlSerializerFormatters() //Soporte para formato de respuesta XML */; 

builder.Services.AddJwt(builder.Configuration); //Aplicacion de JWT




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Usar servicios

app.UseCors("CorsPolicy");
app.UseIpRateLimiting();


//

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
