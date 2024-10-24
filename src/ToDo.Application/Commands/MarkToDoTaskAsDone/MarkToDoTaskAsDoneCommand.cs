using MediatR;

namespace ToDo.Application.Commands.MarkToDoTaskAsDone;

/// <summary>
/// Command for marking ToDoTask as done
/// </summary>
/// <param name="Id"></param>
public record MarkToDoTaskAsDoneCommand(Guid Id) : IRequest;