using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Commands.CreateToDoTask;

namespace ToDo.Api.Controllers;

public sealed class ToDoTasksController : BaseApiController
{
    [HttpPost]
    public async Task CreateToDoTask(CreateToDoTaskCommand command)
    {
        await Mediator.Send(command);
    }

}