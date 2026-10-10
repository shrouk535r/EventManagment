using TaskManagement.Domain.Interfaces.Repositories;
using TaskManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Infrastructure.Repositories
{
    internal class TaskRepository : ITaskRepository
    {
        private TaskDBContext _context;
        public TaskRepository( TaskDBContext context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<Domain.Entities.Tasks.Task>> GetTasks()
        {
            return await _context.Tasks.Include(t => t.Project).ToListAsync();
        }
        public async Task<IEnumerable<Domain.Entities.Tasks.Task>> GetByUser(Guid userId)
        {
            return await _context.Tasks.Include(T => T.Project)
                .Where(T => T.Project.UserId == userId).ToListAsync();
        }
        public async Task<IEnumerable<Domain.Entities.Tasks.Task>> GetByProject(Guid ProjectId)
        {
            return await _context.Tasks.Include(T => T.Project)
                .Where(T => T.ProjectId == ProjectId).ToListAsync();
        }
        public async Task<Domain.Entities.Tasks.Task?> GetById(Guid TaskId)
        {
            return await _context.Tasks.Include(t => t.Project).Include(t => t.Comments)
                .FirstOrDefaultAsync(T => T.Id == TaskId);
        }
        public async Task Add(Domain.Entities.Tasks.Task task)
        {
            await _context.Tasks.AddAsync(task);
        }
        public void Update(Domain.Entities.Tasks.Task task)
        {
            _context.Tasks.Update(task);
        }
        public void Delete(Domain.Entities.Tasks.Task task)
        {
            _context.Tasks.Remove(task);
        }
    }
}
