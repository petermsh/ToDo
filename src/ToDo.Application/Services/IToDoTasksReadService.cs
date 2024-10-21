namespace ToDo.Application.Services;

public interface IToDoTasksReadService
{
    Task<bool> ExistsByTitleAsync(string title);
}