using ToDo.Domain.Entities;

namespace ToDo.Domain.Repositories;

public interface IToDoTaskRepository
{
    Task<ToDoTask> GetAsync(Guid id, CancellationToken cancellationToken);
    Task AddAsync(ToDoTask toDoTask, CancellationToken cancellationToken);
    Task UpdateAsync(ToDoTask toDoTask, CancellationToken cancellationToken);
    Task DeleteAsync(ToDoTask toDoTask, CancellationToken cancellationToken);
}