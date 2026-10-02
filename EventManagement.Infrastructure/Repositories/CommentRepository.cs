using EventManagement.Domain.Interfaces.Repositories;
using EventManagement.Domain.Entities.Comments;
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
    internal class CommentRepository:ICommentRepository
    {
        private EventDBContext _context;
        public CommentRepository(EventDBContext context)
        {
            _context=context;
        }
        public async Task<IEnumerable<Comment>> GetComments(Guid TaskId)
        {
            return await _context.Comments.Where(C => C.TaskId == TaskId).ToListAsync();
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
