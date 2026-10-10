using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Comments.Queries.DTOS
{
    public sealed record CommentDto(Guid id, DateOnly CreatedAt, DateOnly UpdatedAt,string Content, String UserName);
}
