using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Application.Features.Comments.Commands.CreateComment
{
    public sealed record CreateCommentCommand(string Content,Guid TaskId,Guid UserId):IRequest<Guid>;
}
