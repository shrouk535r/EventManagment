using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Tasks.Commands.DeleteTask
{
    public sealed record DeleteTaskCommand(Guid id):IRequest<bool>;
}
