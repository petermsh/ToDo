namespace ToDo.Application.Services;

/// <summary>
/// Interface for service responsible for reading some of the ToDoTask data
/// </summary>
public interface IToDoTasksReadService
{
    // Method for check if a ToDoTask with given title already exists
    Task<bool> ExistsByTitleAsync(string title);
}