namespace ToDo.Domain.Entities;

public class ToDoTask : BaseEntity
{
    public DateTimeOffset ExpiryAt { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int CompletionPercentage { get; private set; }

    private ToDoTask(DateTimeOffset expiryAt, string title, string description, int completionPercentage)
    {
        Id = Guid.NewGuid();
        ExpiryAt = expiryAt;
        Title = title;
        Description = description;
        CompletionPercentage = completionPercentage;
    }

    public static ToDoTask Create(string title, string description, DateTimeOffset expiryAt, int completionPercentage)
        => new(expiryAt, title, description, completionPercentage);

}