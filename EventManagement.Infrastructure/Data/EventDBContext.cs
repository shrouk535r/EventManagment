using EventManagement.Domain.Entities;
using EventManagement.Domain.Entities.Comments;
using EventManagement.Domain.Entities.Projects;
using EventManagement.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task = EventManagement.Domain.Entities.Tasks.Task;

namespace EventManagement.Infrastructure.Data
{
    public class EventDBContext : DbContext
    {
        public EventDBContext(DbContextOptions options) : base(options)
        { }
        public DbSet<User> Users { get; set; }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Project).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Task).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Comment).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(User).Assembly);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var updatedEntries = ChangeTracker.Entries<BaseEntity>()
                .Where(E => E.State == EntityState.Added || E.State == EntityState.Modified)
                .ToList(); ;
            foreach (var entry in updatedEntries)
            {
                var entity = (BaseEntity) entry.Entity;
                if (entry.State == EntityState.Added)
                    entity.CreatedAt = DateTime.Now;
                entity.UpdatedAt = DateTime.Now;
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
