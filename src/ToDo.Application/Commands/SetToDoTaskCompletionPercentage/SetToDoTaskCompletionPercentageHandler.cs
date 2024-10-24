using MediatR;
using ToDo.Application.Exceptions;
using ToDo.Domain.Repositories;

namespace ToDo.Application.Commands.SetToDoTaskCompletionPercentage;

/// <summary>
/// Handler for setting CompletionPercentage
/// </summary>
/// <param name="repository"></param>
internal sealed class SetToDoTaskCompletionPercentageHandler(IToDoTaskRepository repository)
        : IRequestHandler<SetToDoTaskCompletionPercentageCommand>
{
    public async Task Handle(SetToDoTaskCompletionPercentageCommand command, CancellationToken cancellationToken)
    {
        // Get ToDoTask with given id
        var toDo = await repository.GetAsync(command.Id, cancellationToken);

        // Throw exception if ToDoTask was not found
        if (toDo is null)
        {
            throw new ToDoTaskNotFoundException(command.Id.ToString());
        }

        // Setting CompletionPercentage
        toDo.SetCompletionPercentage(command.CompletionPercentage);

        // Update ToDoTask
        await repository.UpdateAsync(toDo, cancellationToken);
    }
}