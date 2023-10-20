
using Domain.Interfaces;
using Aplicacion.UnitOfWork;
using Application.Repository;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using API.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ApiPetshop.Extensions;

public static class ApplicationServiceExtension
{
    public static void ConfigureCors(this IServiceCollection services) =>
    services.AddCors(options =>
    {
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
    });

    public static void AddApplicationServices(this IServiceCollection services)
    {
        // services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        //services.AddScoped<ICita, CitaRepository>();
        //servies.AddScoped<IMascota, MascotaRepository>();        
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }


    // Implementar RateLimit
    public static void ConfigureRateLimiting(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        services.AddInMemoryRateLimiting();
        services.Configure<IpRateLimitOptions>(options =>
        {
            options.EnableEndpointRateLimiting = true;
            options.StackBlockedRequests = false;
            options.HttpStatusCode = 429;
            options.RealIpHeader = "X-Real-IP";
            options.GeneralRules = new List<RateLimitRule>
            {
                new RateLimitRule
                {
                    Endpoint = "*",
                    Period = "10s",
                    Limit = 5 // Permitir maximo 5 peticiones en un rango de tiempo de 10 segundos para todos los EndPoints.
                }
            };
        });
    }


    // Implementar Versionado
    public static void ConfigureApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1,0); // Especificar la versión de la api
            options.AssumeDefaultVersionWhenUnspecified = true; //Tomar esa versión cuando no se especifique explícitamente al consumir

            // añadir la siguiente configuración para soportar el versionado mediante QueryString y mediante Headers:
            // options.ApiVersionReader = new QueryStringApiVersionReader("ver");
            options.ApiVersionReader = ApiVersionReader.Combine(
                new QueryStringApiVersionReader("Ver"),
                new HeaderApiVersionReader("X-Version")
            );
        
        });
    }

    // Implementar JWT
    public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
    {
        //Configuracion de AppSettings
        services.Configure<JWT>(configuration.GetSection("JWT"));

        //Agrega Autenticacion - JWT
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))
                };
            }); 
    }



}
