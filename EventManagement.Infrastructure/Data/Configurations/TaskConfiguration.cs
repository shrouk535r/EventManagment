using EventManagement.Domain.Entities.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Task = EventManagement.Domain.Entities.Tasks.Task;
namespace EventManagement.Infrastructure.Data.Configurations
{
    internal class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title).HasMaxLength(200).IsRequired();            
            builder.HasOne(t => t.Project).WithMany(p => p.Tasks).HasForeignKey(t => t.ProjectId);
            builder.HasMany(t => t.Comments).WithOne(c => c.Task).HasForeignKey(c => c.TaskId);
        }
    }
}
