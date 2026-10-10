using EventManagement.Application.Excepitions;
using EventManagement.Domain.Entities.Comments;
using EventManagement.Domain.Entities.Projects;
using EventManagement.Domain.Interfaces.Repositories;
using EventManagement.Domain.Interfaces.UOW;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Application.Features.Comments.Commands.CreateComment
{
    public sealed class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Guid>
    {
        private ICommentRepository _commentRepository;
        private ITaskRepository _taskRepository;
        private IUnitOfWork _unitOfWork; 
        public CreateCommentCommandHandler(ICommentRepository commentRepository, IUnitOfWork unitOfWork, ITaskRepository taskRepository)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
            _taskRepository = taskRepository;
        }

        public async Task<Guid> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetById(request.TaskId);
            if (task == null)
                throw new NotFoundException(nameof(Domain.Entities.Tasks.Task), request.TaskId);
            if (!Guid.TryParse(request.UserId, out var userId))
                throw new ConflictException("id cannot convert to Guid");

         
            var comment = new Comment
            {
                Content = request.Content,
                UserId = userId,
                TaskId = request.TaskId
            };
            await _commentRepository.Add(comment);
            await _unitOfWork.Save();
            return comment.Id;
        }
    }
}
