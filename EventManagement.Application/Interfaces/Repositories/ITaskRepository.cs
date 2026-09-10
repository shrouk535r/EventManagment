using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManagement.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace EventManagement.Application.Interfaces.Repositories
{
    public interface ITaskRepository
    {
        public Task<IEnumerable<Domain.Entities.Task>> GetByProject(Guid ProjectId);
        public Task<Domain.Entities.Task> GetById(Guid TaskId);
        public Task Add(Domain.Entities.Task task);
        public void Update(Domain.Entities.Task task);
        public void Delete (Domain.Entities.Task task);
    }
}
