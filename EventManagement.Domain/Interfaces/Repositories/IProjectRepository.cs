using EventManagement.Domain.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace EventManagement.Domain.Interfaces.Repositories
{
    public interface IProjectRepository
    {
        public Task<IEnumerable<Project>> GetAll();
        public Task<IEnumerable<Project>> GetbyUser(Guid UserId);
        public Task<Project> GetById(Guid ProjectId);
        public Task Add(Project project);
        public void Update(Project project);
        public void Delete(Project Project);
    }
}
