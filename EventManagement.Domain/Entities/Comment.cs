using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Domain.Entities
{
    public class Comment: BaseEntity
    {
        public string Content { get; set; }
        public string UserName { get; set; }
        public Guid TaskId { get; set; }
        public Task Task { get; set; }
    }
}
