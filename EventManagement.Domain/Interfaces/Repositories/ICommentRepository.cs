using EventManagement.Domain.Entities.Comments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace EventManagement.Domain.Interfaces.Repositories
{
    public interface ICommentRepository
    {
        public Task<IEnumerable<Comment>> GetCommentsByTask(Guid TaskId);
        public Task<Comment>GetById(Guid CommentId);
        public Task Add(Comment comment);
        public void Update(Comment comment);
        public void Delete(Comment comment);
    }
}
