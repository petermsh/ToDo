using MediatR;
using ToDo.Application.Exceptions;
using ToDo.Application.Services;
using ToDo.Domain.Repositories;
using ToDoTask = ToDo.Domain.Entities.ToDoTask;

namespace ToDo.Application.Commands.CreateToDoTask;

internal sealed class CreateToDoTaskHandler(
    IToDoTaskRepository repository,
    IToDoTasksReadService readService) 
    : IRequestHandler<CreateToDoTaskCommand>
{
    public async Task Handle(CreateToDoTaskCommand command, CancellationToken cancellationToken)
    {
        var (title, description, expiryAt, completionPercentage) = command;
        
        if (await readService.ExistsByTitleAsync(title))
        {
            throw new ToDoTaskAlreadyExistsException(title);
        }

        var toDo = ToDoTask.Create(title, description, expiryAt, completionPercentage);

        await repository.AddAsync(toDo, cancellationToken);
    }
}