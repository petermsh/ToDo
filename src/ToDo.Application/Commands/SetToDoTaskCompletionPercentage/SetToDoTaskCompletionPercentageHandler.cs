using FluentValidation;
using MediatR;
using ToDo.Application.Exceptions;
using ToDo.Domain.Repositories;
using ValidationException = ToDo.Application.Exceptions.ValidationException;

namespace ToDo.Application.Commands.SetToDoTaskCompletionPercentage;

/// <summary>
/// Handler for setting CompletionPercentage
/// </summary>
/// <param name="repository"></param>
internal sealed class SetToDoTaskCompletionPercentageHandler(IToDoTaskRepository repository,
    IValidator<SetToDoTaskCompletionPercentageCommand> validator)
        : IRequestHandler<SetToDoTaskCompletionPercentageCommand>
{
    public async Task Handle(SetToDoTaskCompletionPercentageCommand command, CancellationToken cancellationToken)
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

        // Setting CompletionPercentage
        toDo.SetCompletionPercentage(command.CompletionPercentage);

        // Update ToDoTask
        await repository.UpdateAsync(toDo, cancellationToken);
    }
}