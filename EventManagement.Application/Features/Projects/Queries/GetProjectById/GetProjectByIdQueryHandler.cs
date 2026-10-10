using EventManagement.Application.Excepitions;
using EventManagement.Application.Features.Projects.Queries.DTOS;
using EventManagement.Domain.Entities.Projects;
using EventManagement.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Application.Features.Projects.Queries.GetProjectById
{
    public sealed class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDetailsDto>
    {
        private readonly IProjectRepository _projectRepository;

        public GetProjectByIdQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository=projectRepository;
        }

        public async Task<ProjectDetailsDto> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetById(request.id);
            if (project == null)
                throw new NotFoundException(nameof(Project), request.id);
            return new ProjectDetailsDto(project.Id,
                DateOnly.FromDateTime(project.CreatedAt),
                DateOnly.FromDateTime(project.UpdatedAt),
                project.Name, project.Description, project.Completed, project.User.Name
                , project.Tasks?.Select(t => t.Title).ToList() ?? new List<string>());

        }
    }
}
