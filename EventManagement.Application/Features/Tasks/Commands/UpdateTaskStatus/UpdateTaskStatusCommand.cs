using EventManagement.Domain.Entities.Tasks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Application.Features.Tasks.Commands.UpdateTaskStatus
{
    public sealed record UpdateTaskStatusCommand(Guid TaskId, TaskStatusEnum NewStatus):IRequest<bool>;
}
