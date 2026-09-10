using EventManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace EventManagement.Application.Interfaces.Repositories
{
    public interface IProjectRepository
    {
        public Task<IEnumerable<Project>> GetAll();
        public Task<IEnumerable<Project>> GetbyUser(string UserName);
        public Task<Project> GetById(Guid ProjectId);
        public Task Add(Project project);
        public void Update(Project project);
        public void Delete(Project Project);
    }
}
