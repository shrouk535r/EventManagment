using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Application.Features.Projects.Commands.CreateProject
{
    public sealed record CreateProjectCommand(string Name, string Description, string UserId):IRequest<Guid>;
}
