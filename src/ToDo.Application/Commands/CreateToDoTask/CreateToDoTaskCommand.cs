using MediatR;

namespace ToDo.Application.Commands.CreateToDoTask;

/// <summary>
/// Command with necessary data for ToDoTask creation
/// </summary>
/// <param name="Title"></param>
/// <param name="Description"></param>
/// <param name="ExpiryAt"></param>
/// <param name="CompletionPercentage"></param>
public record CreateToDoTaskCommand(string Title, string Description, DateTime ExpiryAt, int CompletionPercentage) : IRequest;