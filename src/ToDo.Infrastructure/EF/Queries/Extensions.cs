using ToDo.Application.Queries.GetAll;
using ToDo.Domain.Entities;

namespace ToDo.Infrastructure.EF.Queries;

/// <summary>
/// Extension methods for ToDoTask entity
/// </summary>
internal static class Extensions
{
    // Cast ToDoTask entity to Dto 
    public static ToDoTaskDto AsDto(this ToDoTask toDoTask)
        => new()
        {
            Id = toDoTask.Id,
            Title = toDoTask.Title,
            CompletionPercentage = toDoTask.CompletionPercentage
        };
}