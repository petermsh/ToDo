namespace ToDo.Domain.Entities;

public class ToDoTask : BaseEntity
{
    public DateTimeOffset ExpiryAt { get; private set; }
    public string Title { get; private set; }
    public string Descrpiton { get; private set; }
    public int CompletionPercentage { get; private set; }
    
}