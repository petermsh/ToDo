using MediatR;

namespace ToDo.Application.Queries.GetAll;

/// <summary>
/// Query definition
/// </summary>
public record GetAllToDoTasksQuery() : IRequest<IEnumerable<ToDoTaskDto>>; 