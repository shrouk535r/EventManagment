using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Domain.Entities
{
    public class Project:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public ICollection<Task>? Tasks { get; set; }
    }
}
