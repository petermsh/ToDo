using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Queries.GetSpecific;

namespace ToDo.Infrastructure.EF.Queries.Handlers;

/// <summary>
/// Handler for getting specific ToDoTask by id
/// </summary>
/// <param name="dbContext"></param>
internal sealed class GetSpecificToDoTaskHandler(ToDoDbContext dbContext)
    : IRequestHandler<GetSpecificToDoTaskQuery, SpecificToDoTaskDto>
{
    public async Task<SpecificToDoTaskDto> Handle(GetSpecificToDoTaskQuery query, CancellationToken cancellationToken)
        => await dbContext.ToDoTasks
            .Where(t => t.Id == query.Id)
            .Select(t => t.AsSpecificDto())
            .AsNoTracking()
            .SingleOrDefaultAsync(cancellationToken);
}