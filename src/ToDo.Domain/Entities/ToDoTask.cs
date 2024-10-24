using System.ComponentModel.DataAnnotations;

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

    // Method for creating ToDoTask
    public static ToDoTask Create(string title, string description, DateTimeOffset expiryAt, int completionPercentage)
        => new(expiryAt, title, description, completionPercentage);


    // Method for updating ToDoTask info
    public void Update(string title, string description, DateTimeOffset expiryAt)
    {
        Title = title;
        Description = description;
        ExpiryAt = expiryAt;
        ModifiedAt = DateTimeOffset.UtcNow;
    }
    
    //Method for setting CompletionPercentage
    public void SetCompletionPercentage(int completionPercentage)
        => CompletionPercentage = completionPercentage;
}