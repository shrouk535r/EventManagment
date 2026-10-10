using EventManagement.Application.Features.Comments.Queries.DTOS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Application.Features.Comments.Queries.GetCommentsByTaskId
{
    public sealed record GetCommentsByTaskIdQuery(Guid taskId):IRequest<List<CommentDto>>;
}
