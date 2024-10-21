using Microsoft.EntityFrameworkCore;
using ToDo.Application.Services;

namespace ToDo.Infrastructure.EF.Services;

internal sealed class ToDoTasksReadService(ToDoDbContext dbContext) : IToDoTasksReadService
{
    public async Task<bool> ExistsByTitleAsync(string title)
        => await dbContext.ToDoTasks.AnyAsync(t => t.Title == title);
}