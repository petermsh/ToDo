namespace ToDo.Application.Queries.GetAll;

/// <summary>
/// DTO for query all ToDoTasks
/// </summary>
public class ToDoTaskDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int CompletionPercentage { get; set; }
    public DateTimeOffset ExpiryAt { get; set; }
}