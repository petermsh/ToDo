using MediatR;

namespace ToDo.Application.Commands.DeleteToDoTask;

/// <summary>
/// Command for deleting ToDoTask by given id
/// </summary>
public record DeleteToDoTaskCommand(Guid Id) : IRequest;