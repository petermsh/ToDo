using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Queries.GetAll;

namespace ToDo.Infrastructure.EF.Queries.Handlers;

/// <summary>
/// Handler for getting all ToDoTasks
/// </summary>
/// <param name="dbContext"></param>
internal sealed class GetAllToDoTasksHandler(ToDoDbContext dbContext) 
    : IRequestHandler<GetAllToDoTasksQuery, IEnumerable<ToDoTaskDto>>
{
    public async Task<IEnumerable<ToDoTaskDto>> Handle(GetAllToDoTasksQuery query, CancellationToken cancellationToken)
        => await dbContext.ToDoTasks
            .Select(t => t.AsDto())
            .AsNoTracking()
            .ToListAsync(cancellationToken);
}