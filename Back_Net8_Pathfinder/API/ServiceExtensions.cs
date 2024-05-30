using Core.Interfaces;
using Core.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Back_Net8_Pathfinder;

public static class ServiceExtensions
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddTransient<IService, Service>();
        return services;
    }

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ConexionSQL")));

        services.AddTransient<IActividadRepository, ActividadRepository>();
        services.AddTransient<IConquistadorRepository, ConquistadorRepository>();
        services.AddTransient<IParametroRepository, ParametroRepository>();
        services.AddTransient<IRolRepository, RolRepository>();
        services.AddTransient<IRolUsuarioRepository, RolUsuarioRepository>();
        services.AddTransient<ISesionRepository, SesionRepository>();
        services.AddTransient<IUsuarioRepository, UsuarioRepository>();
        return services;
    }
}