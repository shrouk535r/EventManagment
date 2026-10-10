using TaskManagement.Application.Features.Tasks.Queries.DTOS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Tasks.Queries.GetTasks
{
    public sealed record GetTasksQuery:IRequest<List<TaskDto>>;
}
