using TaskManagement.Application.Features.Tasks.Queries.DTOS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Tasks.Queries.GetTasksByUserId
{
    public sealed record GetTasksByUserIdQuery(Guid userId):IRequest<List<TaskDto>>;
}
