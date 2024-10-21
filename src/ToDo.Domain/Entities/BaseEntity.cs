namespace ToDo.Domain.Entities;

/// <summary>
/// Base properties for entities
/// </summary>
public class BaseEntity
{ 
    public Guid Id { get; protected set; }
    public DateTimeOffset CreatedAt { get; private set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? ModifiedAt { get; private set; }
}