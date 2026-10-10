using TaskManagement.Application.Excepitions;
using TaskManagement.Application.Features.Projects.Queries.DTOS;
using TaskManagement.Application.Features.Projects.Queries.GetProjectById;
using TaskManagement.Domain.Entities.Projects;
using TaskManagement.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Projects.Queries.GetProjectsByUserId
{
    public sealed class GetProjectByUserIdQueryHandler : IRequestHandler<GetProjectByUserIdQuery, List<ProjectDto>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetProjectByUserIdQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<ProjectDto>> Handle(GetProjectByUserIdQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetbyUser(request.userId);
            if (projects == null)
                throw new NotFoundException(nameof(Project), request.userId);
            var projectsDto = projects.Select(P => new ProjectDto
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
