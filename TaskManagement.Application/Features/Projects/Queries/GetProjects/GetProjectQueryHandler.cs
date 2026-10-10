using TaskManagement.Application.Excepitions;
using TaskManagement.Application.Features.Projects.Queries.DTOS;
using TaskManagement.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Projects.Queries.GetProjects
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
            if (projects == null)
                throw new NotFoundException("There are No Projects Added Yet");
            var projectsDto =projects.Select(P => new ProjectDto 
            ( 
                P.Id,
                P.Name,
                P.Description,
                P.Completed,
                P.User.Name
            )).ToList();
            return projectsDto;
        }
    }
}
