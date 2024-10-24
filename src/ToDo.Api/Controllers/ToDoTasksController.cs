using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Commands.CreateToDoTask;
using ToDo.Application.Commands.SetToDoTaskCompletionPercentage;
using ToDo.Application.Commands.UpdateToDoTask;
using ToDo.Application.Queries.GetAll;
using ToDo.Application.Queries.GetIncoming;
using ToDo.Application.Queries.GetSpecific;

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
    
    // Endpoint for getting specific ToDoTask by id
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<SpecificToDoTaskDto>> GetSpecificToDoTask([FromRoute] Guid id)
        => OkOrNotFound(await Mediator.Send(new GetSpecificToDoTaskQuery { Id = id }));
    
    // Endpoint for getting incoming ToDoTasks
    [HttpGet("incoming")]
    public async Task<ActionResult<IEnumerable<ToDoTaskDto>>> GetIncomingToDoTasks([FromQuery] TimeFilter filter)
        => OkOrNotFound(await Mediator.Send(new GetIncomingToDoTasksQuery() { TimeFiler = filter }));

    // Endpoint for updating ToDoTask info
    [HttpPut("{id:guid}")]
    public async Task UpdateToDoTask([FromRoute] Guid id, UpdateToDoTaskData data)
        => await Mediator.Send(new UpdateToDoTaskCommand
            {
                Id = id, 
                Title = data.title,
                Description = data.description,
                ExpiryAt = data.expiryAt
            });
    
    // Endpoint for setting ToDoTask CompletionPercentage
    [HttpPatch("{id:guid}")]
    public async Task SetCompletionPercentage([FromRoute] Guid id, int completionPercentage)
        => await Mediator.Send(new SetToDoTaskCompletionPercentageCommand {Id = id, CompletionPercentage = completionPercentage });
}