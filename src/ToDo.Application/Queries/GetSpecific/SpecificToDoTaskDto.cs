namespace ToDo.Application.Queries.GetSpecific;

/// <summary>
/// Dto for query specific ToDoTask
/// </summary>
public class SpecificToDoTaskDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int CompletionPercentage { get; set; }
    public DateTimeOffset ExpiryAt { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
}