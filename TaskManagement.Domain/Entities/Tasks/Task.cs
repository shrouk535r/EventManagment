using TaskManagement.Domain.Entities.Comments;
using TaskManagement.Domain.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Entities.Tasks
{
    public class Task : BaseEntity
    {
        public string Title{ get; set; }
        public string Description{ get; set; }
        public TaskPriority Priority{ get; set; }
        public TaskStatusEnum Status { get; set; }
        public DateOnly DueDate { get; set;}
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public ICollection<Comment> ?Comments { get; set; }
    }
}
