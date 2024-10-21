using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoEntity = ToDo.Domain.Entities.ToDoTask;

namespace ToDo.Infrastructure.EF.Configurations;

/// <summary>
/// ToDoConfiguration defines configuration for the ToDoTask entity
/// Implementation of IEntityTypeConfiguration allows customizing entity
/// </summary>
internal sealed class ToDoConfiguration : IEntityTypeConfiguration<ToDoEntity>
{
    public void Configure(EntityTypeBuilder<ToDoEntity> builder)
    {
        // Define primary key for the entity
        builder.HasKey(e => e.Id);
            
        // Define the name of the table in the database
        builder.ToTable("ToDoTasks");
    }
}