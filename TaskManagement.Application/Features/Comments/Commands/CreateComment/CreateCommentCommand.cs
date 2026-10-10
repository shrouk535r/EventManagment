using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Comments.Commands.CreateComment
{
    public sealed record CreateCommentCommand(string Content,Guid TaskId,string UserId):IRequest<Guid>;
}
