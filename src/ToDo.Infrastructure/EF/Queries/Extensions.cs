using ToDo.Application.Queries.GetAll;
using ToDo.Application.Queries.GetSpecific;
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
            CompletionPercentage = toDoTask.CompletionPercentage,
            ExpiryAt = toDoTask.ExpiryAt
        };
    
    public static SpecificToDoTaskDto AsSpecificDto(this ToDoTask toDoTask)
        => new()
        {
            Id = toDoTask.Id,
            Title = toDoTask.Title,
            Description = toDoTask.Description,
            CompletionPercentage = toDoTask.CompletionPercentage,
            ExpiryAt = toDoTask.ExpiryAt,
            CreatedAt = toDoTask.CreatedAt,
            ModifiedAt = toDoTask.ModifiedAt
        };
}