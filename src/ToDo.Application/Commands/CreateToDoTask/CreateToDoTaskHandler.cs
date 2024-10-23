using MediatR;
using ToDo.Domain.Repositories;
using ToDoTask = ToDo.Domain.Entities.ToDoTask;

namespace ToDo.Application.Commands.CreateToDoTask;

/// <summary>
/// Handler containing logic for ToDoTask creation
/// </summary>
/// <param name="repository"></param>
/// <param name="readService"></param>
public sealed class CreateToDoTaskHandler(
    IToDoTaskRepository repository) 
    : IRequestHandler<CreateToDoTaskCommand>
{
    public async Task Handle(CreateToDoTaskCommand command, CancellationToken cancellationToken)
    {
        var (title, description, expiryAt, completionPercentage) = command;

        // Create a new ToDoTask entity 
        var toDo = ToDoTask.Create(title, description, expiryAt, completionPercentage);

        // Add the new task to the database
        await repository.AddAsync(toDo, cancellationToken);
    }
}