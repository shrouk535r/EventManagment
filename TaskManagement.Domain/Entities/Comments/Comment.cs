using TaskManagement.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = TaskManagement.Domain.Entities.Tasks.Task;
namespace TaskManagement.Domain.Entities.Comments
{
    public class Comment: BaseEntity
    {
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid TaskId { get; set; }
        public Task Task { get; set; }
    }
}
