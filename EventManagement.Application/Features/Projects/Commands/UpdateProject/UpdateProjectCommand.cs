using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Application.Features.Projects.Commands.UpdateProject
{
    public sealed record UpdateProjectCommand (Guid ProjectId, string Name, string Description, bool IsCompleted,string userId)
    : IRequest<Guid>;
}
