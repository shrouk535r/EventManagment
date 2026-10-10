using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace TaskManagement.Domain.Interfaces.Repositories
{
    public interface ITaskRepository
    {
        public Task<IEnumerable<Domain.Entities.Tasks.Task>> GetTasks();
        public Task<IEnumerable<Domain.Entities.Tasks.Task>> GetByUser(Guid userId);
        public Task<IEnumerable<Domain.Entities.Tasks.Task>> GetByProject(Guid ProjectId);
        public Task<Domain.Entities.Tasks.Task> GetById(Guid TaskId);
        public Task Add(Domain.Entities.Tasks.Task task);
        public void Update(Domain.Entities.Tasks.Task task);
        public void Delete (Domain.Entities.Tasks.Task task);
    }
}
