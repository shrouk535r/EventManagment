using TaskManagement.Domain.Interfaces.Repositories;
using TaskManagement.Domain.Entities.Comments;
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
    internal class CommentRepository:ICommentRepository
    {
        private TaskDBContext _context;
        public CommentRepository(TaskDBContext context)
        {
            _context=context;
        }
        public async Task<IEnumerable<Comment>> GetCommentsByTask(Guid TaskId)
        {
            return await _context.Comments.Include(c => c.User)
                .Where(C => C.TaskId == TaskId).ToListAsync();
        }
        public async Task<Comment?> GetById(Guid CommentId)
        {
            return await _context.Comments.Include(C => C.Task).FirstOrDefaultAsync(C => C.Id==CommentId);
        }
        public async Task Add(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
        }
        public void Update(Comment comment)
        {
            _context.Comments.Update(comment);
        }
        public void Delete(Comment comment)
        {
            _context.Comments.Remove(comment);
        }
    }
}
