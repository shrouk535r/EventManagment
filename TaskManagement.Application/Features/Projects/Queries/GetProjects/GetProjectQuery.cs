using TaskManagement.Application.Features.Projects.Queries.DTOS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Projects.Queries.GetProjects
{
    public sealed record GetProjectQuery:IRequest<List<ProjectDto>>;
}
