using MediatR;
using ToDo.Application.Exceptions;
using ToDo.Domain.Repositories;

namespace ToDo.Application.Commands.DeleteToDoTask;

/// <summary>
/// Handler containing logic for ToDoTask deleting
/// </summary>
/// <param name="repository"></param>
internal sealed class DeleteToDoTaskHandler(IToDoTaskRepository repository)
    : IRequestHandler<DeleteToDoTaskCommand>
{
    public async Task Handle(DeleteToDoTaskCommand command, CancellationToken cancellationToken)
    {
        // Get ToDoTask with given id
        var toDo = await repository.GetAsync(command.Id, cancellationToken);

        // Throw exception if ToDoTask was not found
        if (toDo is null)
        {
            throw new ToDoTaskNotFoundException(command.Id.ToString());
        }

        // Delete ToDoTask
        await repository.DeleteAsync(toDo, cancellationToken);
    }
}