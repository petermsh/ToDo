using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;
using ToDo.Infrastructure.EF;

namespace ToDo.Infrastructure.Repositories;

internal sealed class ToDoTaskRepository(ToDoDbContext dbContext) : IToDoTaskRepository
{
    public Task<ToDoTask> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(ToDoTask toDoTask, CancellationToken cancellationToken)
    {
        await dbContext.ToDoTasks.AddAsync(toDoTask, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task UpdateAsync(ToDoTask toDoTask, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(ToDoTask toDoTask, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}