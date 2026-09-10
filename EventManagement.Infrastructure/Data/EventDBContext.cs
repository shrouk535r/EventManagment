using EventManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task = EventManagement.Domain.Entities.Task;

namespace EventManagement.Infrastructure.Data
{
    public class EventDBContext : DbContext
    {
        public EventDBContext(DbContextOptions options):base(options)
        { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
