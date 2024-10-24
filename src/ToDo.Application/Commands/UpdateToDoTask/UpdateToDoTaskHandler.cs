using MediatR;
using ToDo.Application.Exceptions;
using ToDo.Domain.Repositories;

namespace ToDo.Application.Commands.UpdateToDoTask;

/// <summary>
/// Handler containing logic for ToDoTask updating
/// </summary>
/// <param name="repository"></param>
internal sealed class UpdateToDoTaskHandler(IToDoTaskRepository repository)
    : IRequestHandler<UpdateToDoTaskCommand>
{
    public async Task Handle(UpdateToDoTaskCommand command, CancellationToken cancellationToken)
    {
        // Get ToDoTask with given id
        var toDo = await repository.GetAsync(command.Id, cancellationToken);

        // Throw exception if ToDoTask was not found
        if (toDo is null)
        {
            throw new ToDoTaskNotFoundException(command.Id.ToString());
        }
        
        // Update ToDoTask
        toDo.Update(
            command.Title ?? toDo.Title,
            command.Description ?? toDo.Description,
            command.ExpiryAt ?? toDo.ExpiryAt);
        
        // Update database
        await repository.UpdateAsync(toDo, cancellationToken);
    }
}