using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ToDo.Infrastructure.EF.Postgres;

/// <summary>
/// DatabaseInitializer is responsible for automatic applying database migrations during application starts
/// </summary>
/// <param name="serviceProvider"></param>
internal sealed class DatabaseInitializer(IServiceProvider serviceProvider) : IHostedService
{
    // Method called when the applications starts
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        // Limit DbContext lifetime
        using (var scope = serviceProvider.CreateScope())
        {
            // Get an instance of ToDoDbContext
            var dbContext = scope.ServiceProvider.GetRequiredService<ToDoDbContext>();
            // Applies pending migrations to the database
            await dbContext.Database.MigrateAsync(cancellationToken);
        }

        await Task.CompletedTask;
    }
    
    // Method called when the applications stops
    public async Task StopAsync(CancellationToken cancellationToken)
        => await Task.CompletedTask;
}