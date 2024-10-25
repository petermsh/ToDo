using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Exceptions;
using ToDo.Application.Queries.GetAll;
using ToDo.Application.Queries.GetIncoming;

namespace ToDo.Infrastructure.EF.Queries.Handlers;

/// <summary>
/// Handler for getting incoming ToDoTasks 
/// </summary>
/// <param name="dbContext"></param>
internal sealed class GetIncomingToDoTasksHandler(ToDoDbContext dbContext) 
    : IRequestHandler<GetIncomingToDoTasksQuery, IEnumerable<ToDoTaskDto>>
{
    public async Task<IEnumerable<ToDoTaskDto>> Handle(GetIncomingToDoTasksQuery query,
        CancellationToken cancellationToken)
    {
        // Get only uncompleted todos
        var toDoTasks = dbContext.ToDoTasks
            .Where(t => t.CompletionPercentage < 100)
            .AsQueryable();
        
        // Get current date and time
        var now = DateTimeOffset.UtcNow;
        
        // Calculate end of the selected period
        var endOfPeriod = query.TimeFiler switch
        {
            TimeFilter.Today => now.Date.AddDays(1).AddTicks(-1).ToUniversalTime(),
            TimeFilter.Tomorrow => now.Date.AddDays(2).AddTicks(-1).ToUniversalTime(),
            TimeFilter.CurrentWeek => now.Date.AddDays(-(int)now.DayOfWeek).AddDays(7).AddTicks(-1).ToUniversalTime(),
            _ => throw new InvalidTimeFilterException()
        };
        
        // Select todos ending before selected period
        toDoTasks = toDoTasks.Where(t => t.ExpiryAt <= endOfPeriod);

        
        return await toDoTasks
            .Select(t => t.AsDto())
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}