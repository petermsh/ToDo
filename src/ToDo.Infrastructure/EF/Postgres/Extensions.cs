using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ToDo.Infrastructure.EF.Postgres;

/// <summary>
/// Extension methods for setting up Postgres database
/// </summary>
internal static class Extensions
{
    //Name of the appsettings section that holds the Postgres connection string
    private const string SectionName = "Postgres";
    
    internal static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        // Get Postgres connection string from the appsettings
        var options = configuration.GetOptions<PostgresOptions>(SectionName);
        // Add ToDoDbContext to the service collection
        services.AddDbContext<ToDoDbContext>(ctx =>
            ctx.UseNpgsql(options.ConnectionString));
        
        // Add DatabaseInitializer to the service collection
        services.AddHostedService<DatabaseInitializer>();

        return services;
    }
    
    // Helper method to bind a configuration to the provided generic type T
    private static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        // Create a new instance of the generic type
        var options = new T();
        // Get Postgres connection string from the appsettings 
        var section = configuration.GetSection(sectionName);
        section.Bind(options);

        return options;
    }
}