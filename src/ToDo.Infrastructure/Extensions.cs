using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Infrastructure.EF.Postgres;

namespace ToDo.Infrastructure;

/// <summary>
/// Extension methods for infrastructure layer
/// </summary>
public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //Add Swagger
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        // Add Postgres
        services.AddPostgres(configuration);
        return services;
    }
}