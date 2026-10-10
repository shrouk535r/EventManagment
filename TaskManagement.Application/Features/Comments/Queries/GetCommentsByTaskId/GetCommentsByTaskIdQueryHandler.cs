using TaskManagement.Application.Excepitions;
using TaskManagement.Application.Features.Comments.Queries.DTOS;
using TaskManagement.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Comments.Queries.GetCommentsByTaskId
{
    public sealed class GetCommentsByTaskIdQueryHandler : IRequestHandler<GetCommentsByTaskIdQuery, List<CommentDto>>
    {
        private ICommentRepository _commentRepository;
        public GetCommentsByTaskIdQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<List<CommentDto>> Handle(GetCommentsByTaskIdQuery request, CancellationToken cancellationToken)
        {
            var comments = await _commentRepository.GetCommentsByTask(request.taskId);
            if (comments == null)
                throw new NotFoundException(nameof(comments), request.taskId);
            return comments.Select(c => new CommentDto(
                c.Id,
                DateOnly.FromDateTime(c.CreatedAt),
                DateOnly.FromDateTime(c.UpdatedAt),
                c.Content,
                c.User.Name
                )).ToList();
        
        }
    }
}
