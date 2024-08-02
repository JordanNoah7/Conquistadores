using Core.Interfaces;
using Core.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API;

public static class ServiceExtensions
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddTransient<IService, Service>();
        services.AddTransient<IEmailService, EmailService>();
        return services;
    }

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ConexionSQL")));

        services.AddTransient<IActividadRepository, ActividadRepository>();
        services.AddTransient<IAsistenciaRepository, AsistenciaRepository>();
        services.AddTransient<ICategoriaRepository, CategoriaRepository>();
        services.AddTransient<IClaseRepository, ClaseRepository>();
        services.AddTransient<IConquistadorRepository, ConquistadorRepository>();
        services.AddTransient<IConquistadorItemCuadernilloRepository, ConquistadorItemCuadernilloRepository>();
        services.AddTransient<ICuentaCorrienteRepository, CuentaCorrienteRepository>();
        services.AddTransient<IEspecialidadRepository, EspecialidadRepository>();
        services.AddTransient<IParametroRepository, ParametroRepository>();
        services.AddTransient<IRolRepository, RolRepository>();
        services.AddTransient<IUsuarioRolRepository, UsuarioRolRepository>();
        services.AddTransient<ISesionRepository, SesionRepository>();
        services.AddTransient<ITipoRepository, TipoRepository>();
        services.AddTransient<ITutorRepository, TutorRepository>();
        services.AddTransient<IUnidadRepository, UnidadRepository>();
        services.AddTransient<IUsuarioRepository, UsuarioRepository>();
        return services;
    }
}