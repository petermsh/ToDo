using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoTask = ToDo.Domain.Entities.ToDoTask;

namespace ToDo.Infrastructure.EF.Configurations;

/// <summary>
/// ToDoConfiguration defines configuration for the ToDoTask entity
/// Implementation of IEntityTypeConfiguration allows customizing entity
/// </summary>
internal sealed class ToDoConfiguration : IEntityTypeConfiguration<ToDoTask>
{
    public void Configure(EntityTypeBuilder<ToDoTask> builder)
    {
        // Define primary key for the entity
        builder.HasKey(e => e.Id);
            
        // Define the name of the table in the database
        builder.ToTable("ToDoTasks");
    }
}