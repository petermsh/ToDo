using FluentValidation;
using MediatR;
using ToDo.Application.Exceptions;
using ToDo.Domain.Repositories;
using ValidationException = ToDo.Application.Exceptions.ValidationException;

namespace ToDo.Application.Commands.UpdateToDoTask;

/// <summary>
/// Handler containing logic for ToDoTask updating
/// </summary>
/// <param name="repository"></param>
internal sealed class UpdateToDoTaskHandler(IToDoTaskRepository repository,
    IValidator<UpdateToDoTaskCommand> validator)
    : IRequestHandler<UpdateToDoTaskCommand>
{
    public async Task Handle(UpdateToDoTaskCommand command, CancellationToken cancellationToken)
    {
        // Validate command
        var result = await validator.ValidateAsync(command, cancellationToken);

        // Throw exception if result is invalid
        if (!result.IsValid)
        {
            throw new ValidationException(result);
        }
        
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