using MediatR;
using ToDo.Application.Exceptions;
using ToDo.Domain.Repositories;

namespace ToDo.Application.Commands.MarkToDoTaskAsDone;

/// <summary>
/// Handler containing logic for setting ToDoTask as done
/// </summary>
internal sealed class MarkToDoTaskAsDoneHandler(IToDoTaskRepository repository)
    : IRequestHandler<MarkToDoTaskAsDoneCommand>
{
    public async Task Handle(MarkToDoTaskAsDoneCommand command, CancellationToken cancellationToken)
    {
        // Get ToDoTask with given id
        var toDo = await repository.GetAsync(command.Id, cancellationToken);

        // Throw exception if ToDoTask was not found
        if (toDo is null)
        {
            throw new ToDoTaskNotFoundException(command.Id.ToString());
        }
        // Mark ToDoTask as done
        toDo.MarkAsDone();

        // Update ToDoTask
        await repository.UpdateAsync(toDo, cancellationToken);
    }
}