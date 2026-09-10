using EventManagement.Application.Interfaces.Repositories;
using EventManagement.Domain.Entities;
using EventManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace EventManagement.Infrastructure.Repositories
{
    internal class ProjectRepository:IProjectRepository
    {
        private EventDBContext _context;
        public ProjectRepository(EventDBContext context)
        { 
            _context = context;
        }
        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _context.Projects.ToListAsync();
        }
        public async Task<IEnumerable<Project>?> GetbyUser(string UserName)
        {
            return await _context.Projects.Where(p => p.UserName == UserName).ToListAsync();
        }
        public async Task<Project?> GetById(Guid ProjectId)
        {
            return await _context.Projects.FirstOrDefaultAsync(P => P.Id == ProjectId);
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
