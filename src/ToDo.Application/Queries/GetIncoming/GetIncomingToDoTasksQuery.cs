using MediatR;
using ToDo.Application.Queries.GetAll;

namespace ToDo.Application.Queries.GetIncoming;

/// <summary>
/// Query definition
/// </summary>
public class GetIncomingToDoTasksQuery : IRequest<IEnumerable<ToDoTaskDto>>
{
    public TimeFilter TimeFiler { get; set; }
}