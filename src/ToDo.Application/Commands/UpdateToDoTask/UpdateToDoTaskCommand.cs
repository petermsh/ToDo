using MediatR;

namespace ToDo.Application.Commands.UpdateToDoTask;

/// <summary>
/// Command with updated information for ToDoTask with given id
/// </summary>
public class UpdateToDoTaskCommand : IRequest
{
    public Guid Id { get; init; }
    public string? Title { get; init; }
    public string? Description { get; init; }
    public DateTimeOffset? ExpiryAt { get; init; }
}