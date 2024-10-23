using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Commands.CreateToDoTask;
using ToDo.Application.Queries.GetAll;

namespace ToDo.Api.Controllers;

/// <summary>
/// ToDoTasks controller
/// </summary>
public sealed class ToDoTasksController : BaseApiController
{
    // Endpoint for creating ToDoTask
    [HttpPost]
    public async Task CreateToDoTask(CreateToDoTaskCommand command)
        // Send the command to its handler using MediatR
        => await Mediator.Send(command);

    // Endpoint for getting all ToDoTasks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ToDoTaskDto>>> GetAllToDoTasks()
        => OkOrNotFound(await Mediator.Send(new GetAllToDoTasksQuery()));

}