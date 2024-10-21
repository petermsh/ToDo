using Microsoft.EntityFrameworkCore;

namespace ToDo.Infrastructure.EF;

/// <summary>
/// ToDoDbContext is used for managing database
/// </summary>
/// <param name="options"></param>
internal sealed class ToDoDbContext(DbContextOptions<ToDoDbContext> options) : DbContext(options)
{
    
    public DbSet<Domain.Entities.ToDoTask> ToDoTasks { get; init; }
    
    
    // Method called when the context is being created
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply configurations for entities found in the same assembly as the context
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }
}