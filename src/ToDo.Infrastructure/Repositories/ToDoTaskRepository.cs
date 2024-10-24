using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;
using ToDo.Infrastructure.EF;

namespace ToDo.Infrastructure.Repositories;

/// <summary>
/// Implementation of the IToDoTaskRepository using database context
/// </summary>
/// <param name="dbContext"></param>
internal sealed class ToDoTaskRepository(ToDoDbContext dbContext) : IToDoTaskRepository
{
    // Get a ToDoTask by its ID
    public async Task<ToDoTask> GetAsync(Guid id, CancellationToken cancellationToken)
        => await dbContext.ToDoTasks.SingleOrDefaultAsync(t => t.Id == id, cancellationToken);

    // Add a new ToDoTask to the database
    public async Task AddAsync(ToDoTask toDoTask, CancellationToken cancellationToken)
    {
        await dbContext.ToDoTasks.AddAsync(toDoTask, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
    
    // Update an existing ToDoTask
    public async Task UpdateAsync(ToDoTask toDoTask, CancellationToken cancellationToken)
    {
        dbContext.ToDoTasks.Update(toDoTask);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    // Delete a ToDoTask
    public async Task DeleteAsync(ToDoTask toDoTask, CancellationToken cancellationToken)
    {
        dbContext.ToDoTasks.Remove(toDoTask);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}