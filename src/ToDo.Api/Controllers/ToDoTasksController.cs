using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Commands.CreateToDoTask;

namespace ToDo.Api.Controllers;

/// <summary>
/// ToDoTasks controller
/// </summary>
public sealed class ToDoTasksController : BaseApiController
{
    // Endpoint for creating ToDoTask
    [HttpPost]
    public async Task CreateToDoTask(CreateToDoTaskCommand command)
    {
        // Send the command to its handler using MediatR
        await Mediator.Send(command);
    }

}