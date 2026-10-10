using TaskManagement.Domain.Entities.Comments;
using TaskManagement.Domain.Entities.Projects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Entities.Users
{
    public class User:IdentityUser<Guid>
    {
        public string Name {  get; set; }
        public string City { get; set; }
        public UserRole Role { get; set; }
        public ICollection<Project> ? Projects { get; set; }
        public ICollection<Comment> ? Comments { get; set; }
    }
}
