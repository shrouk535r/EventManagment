using EventManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Domain.Entities
{
    public class Task : BaseEntity
    {
        public string Title{ get; set; }
        public string Description{ get; set; }
        public TaskPriority Priority{ get; set; }
        public bool IsCompleted { get; set; }
        public DateOnly DueDate { get; set;}
        public string UserName { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public ICollection<Comment> ?Comments { get; set; }
    }
}
