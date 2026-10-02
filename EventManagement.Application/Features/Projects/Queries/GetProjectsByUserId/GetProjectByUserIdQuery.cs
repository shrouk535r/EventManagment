using EventManagement.Application.Features.Projects.Queries.DTOS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Application.Features.Projects.Queries.GetProjectsByUserId
{
    public sealed record GetProjectByUserIdQuery(Guid userId) : IRequest<List<ProjectDto>>;

}
