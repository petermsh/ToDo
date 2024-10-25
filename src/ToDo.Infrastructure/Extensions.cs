using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToDo.Application.Exceptions.Middleware;
using ToDo.Domain.Repositories;
using ToDo.Infrastructure.EF.Postgres;
using ToDo.Infrastructure.Repositories;

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
        
        //Add exception middleware
        services.AddScoped<ExceptionMiddleware>();
        
        // Add option to display enum values
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
            });
     
        // Add MediatR and search for handlers to registry
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        // AddRepositories
        services.AddScoped<IToDoTaskRepository, ToDoTaskRepository>();
        
        // Add Postgres
        services.AddPostgres(configuration);
        return services;
    }
    
    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        // Use exception middleware
        app.UseMiddleware<ExceptionMiddleware>();
        
        app.MapControllers();
        
        return app;
    }
}