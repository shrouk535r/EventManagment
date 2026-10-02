using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Application.Features.Projects.Commands.DeleteProject
{
    public sealed record DeleteProjectCommand(Guid ProjectId):IRequest<bool>;
}
