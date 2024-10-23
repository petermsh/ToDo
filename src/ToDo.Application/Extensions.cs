using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace ToDo.Application;

/// <summary>
/// Extension methods for application layer
/// </summary>
public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Add MediatR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}