using MediatR;
using ToDo.Application.Exceptions;
using ToDo.Application.Services;
using ToDo.Domain.Repositories;
using ToDoTask = ToDo.Domain.Entities.ToDoTask;

namespace ToDo.Application.Commands.CreateToDoTask;

/// <summary>
/// Handler containing logic for ToDoTask creation
/// </summary>
/// <param name="repository"></param>
/// <param name="readService"></param>
public sealed class CreateToDoTaskHandler(
    IToDoTaskRepository repository,
    IToDoTasksReadService readService) 
    : IRequestHandler<CreateToDoTaskCommand>
{
    public async Task Handle(CreateToDoTaskCommand command, CancellationToken cancellationToken)
    {
        var (title, description, expiryAt, completionPercentage) = command;
        
        // Check if a ToDoTask with the same title already exists
        if (await readService.ExistsByTitleAsync(title))
        {
            // If exists throw exception
            throw new ToDoTaskAlreadyExistsException(title);
        }

        // Create a new ToDoTask entity 
        var toDo = ToDoTask.Create(title, description, expiryAt, completionPercentage);

        // Add the new task to the database
        await repository.AddAsync(toDo, cancellationToken);
    }
}