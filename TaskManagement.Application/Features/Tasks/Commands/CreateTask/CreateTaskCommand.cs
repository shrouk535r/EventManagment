using TaskManagement.Domain.Entities.Tasks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Tasks.Commands.CreateTask
{
    public sealed record CreateTaskCommand(string Title, string Description, TaskPriority TaskPriority, DateOnly DueDate,Guid ProjectId,string userId)
     : IRequest<Guid>;
}
