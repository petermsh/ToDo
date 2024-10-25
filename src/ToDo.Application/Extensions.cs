using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Application.Exceptions.Middleware;

namespace ToDo.Application;

/// <summary>
/// Extension methods for application layer
/// </summary>
public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Add MediatR and search for handlers to registry
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        // Add validators
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        return services;
    }
}