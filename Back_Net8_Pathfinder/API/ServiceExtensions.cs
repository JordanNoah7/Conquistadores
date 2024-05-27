using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Back_Net8_Pathfinder;

public static class ServiceExtensions
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConexionSQL")));
        return services;
    }
}