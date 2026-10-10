using TaskManagement.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task = TaskManagement.Domain.Entities.Tasks.Task;
namespace TaskManagement.Domain.Entities.Projects
{
    public class Project:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<Task>? Tasks { get; set; }
    }
}
