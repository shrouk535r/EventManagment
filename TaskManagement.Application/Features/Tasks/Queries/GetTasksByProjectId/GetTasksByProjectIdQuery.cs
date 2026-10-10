using TaskManagement.Application.Features.Tasks.Queries.DTOS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Tasks.Queries.GetTasksByProjectId
{
    public sealed record GetTasksByProjectIdQuery(Guid projectId):IRequest<List<TaskDto>>;
}
