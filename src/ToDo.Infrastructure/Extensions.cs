using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Application.Services;
using ToDo.Domain.Repositories;
using ToDo.Infrastructure.EF.Postgres;
using ToDo.Infrastructure.EF.Services;
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
        services.AddControllers();
        
        // AddRepositories
        services.AddScoped<IToDoTaskRepository, ToDoTaskRepository>();
        services.AddScoped<IToDoTasksReadService, ToDoTasksReadService>();
        
        // Add Postgres
        services.AddPostgres(configuration);
        return services;
    }
}