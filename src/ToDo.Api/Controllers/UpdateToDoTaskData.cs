using MediatR;

namespace ToDo.Api.Controllers;

/// <summary>
/// Record for getting a new data for ToDoTask
/// </summary>
/// <param name="title"></param>
/// <param name="description"></param>
/// <param name="expiryAt"></param>
public record UpdateToDoTaskData(string? title, string? description, DateTimeOffset? expiryAt) : IRequest;