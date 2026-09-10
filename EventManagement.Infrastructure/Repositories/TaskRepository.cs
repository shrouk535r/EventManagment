using EventManagement.Application.Interfaces.Repositories;
using EventManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Infrastructure.Repositories
{
    internal class TaskRepository : ITaskRepository
    {
        private EventDBContext _context;
        public TaskRepository( EventDBContext context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<Domain.Entities.Task>> GetByProject(Guid ProjectId)
        {
            return await _context.Tasks.Where(T => T.ProjectId == ProjectId).ToListAsync();
        }
        public async Task<Domain.Entities.Task?> GetById(Guid TaskId)
        {
            return await _context.Tasks.FirstOrDefaultAsync(T => T.Id == TaskId);
        }
        public async Task Add(Domain.Entities.Task task)
        {
            await _context.Tasks.AddAsync(task);
        }
        public void Update(Domain.Entities.Task task)
        {
            _context.Tasks.Update(task);
        }
        public void Delete(Domain.Entities.Task task)
        {
            _context.Tasks.Remove(task);
        }
    }
}
