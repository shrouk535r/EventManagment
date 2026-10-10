using TaskManagement.Domain.Interfaces.Repositories;
using TaskManagement.Domain.Entities.Projects;
using TaskManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace TaskManagement.Infrastructure.Repositories
{
    internal class ProjectRepository:IProjectRepository
    {
        private TaskDBContext _context;
        public ProjectRepository(TaskDBContext context)
        { 
            _context = context;
        }
        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _context.Projects.Include(P => P.User).ToListAsync();
        }
        public async Task<IEnumerable<Project>?> GetbyUser(Guid UserId)
        {
            return await _context.Projects.Include(P => P.User).Include(P => P.Tasks).Where(p => p.UserId == UserId).ToListAsync();
        }
        public async Task<Project?> GetById(Guid ProjectId)
        {
            return await _context.Projects.Include(P => P.User).Include(P => P.Tasks).FirstOrDefaultAsync(P => P.Id == ProjectId);
        }
        public async Task Add(Project project)
        {
            await _context.Projects.AddAsync(project);
        }
        public void Update(Project project)
        {
            _context.Projects.Update(project);
        }
        public void Delete(Project Project) 
        {
            _context.Projects.Remove(Project); 
        }
    }
}
