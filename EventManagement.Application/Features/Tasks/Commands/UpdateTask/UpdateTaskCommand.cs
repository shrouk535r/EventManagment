using EventManagement.Domain.Entities.Tasks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Application.Features.Tasks.Commands.UpdateTask
{
    public sealed record UpdateTaskCommand(Guid TaskId, string Title, string Description, TaskPriority TaskPriority, DateOnly DueDate)
        :IRequest<Guid>;
}
