using EventManagement.Application.Features.Projects.Queries.DTOS;
using EventManagement.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Application.Features.Projects.Queries.GetProjects
{
    public sealed class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, List<ProjectDto>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetProjectQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<ProjectDto>> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetAll();
            var projectsDto =projects.Select(P => new ProjectDto 
            ( 
                P.Name,
                P.Description,
                P.Completed,
                P.User.Name
            )).ToList();
            return projectsDto;
        }
    }
}
