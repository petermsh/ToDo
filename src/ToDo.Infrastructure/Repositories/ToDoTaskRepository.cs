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
    public Task<ToDoTask> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    // Add a new ToDoTask to the database
    public async Task AddAsync(ToDoTask toDoTask, CancellationToken cancellationToken)
    {
        await dbContext.ToDoTasks.AddAsync(toDoTask, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
    
    // Update an existing ToDoTask
    public Task UpdateAsync(ToDoTask toDoTask, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    // Delete a ToDoTask
    public Task DeleteAsync(ToDoTask toDoTask, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}