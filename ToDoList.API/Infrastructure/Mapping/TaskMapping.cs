using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.API.Domain;

namespace ToDoList.API.Infrastructure.Mapping;

public class TaskMapping : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Title)
            .HasMaxLength(300).IsRequired();

        builder.Property(i => i.IsCompleted)
            .HasDefaultValue(false).IsRequired();

        builder.Property(i => i.CreationTime)
            .IsRequired();
    }
}
