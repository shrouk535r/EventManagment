using EventManagement.Application.Excepitions;
using EventManagement.Application.Features.Projects.Commands.DeleteProject;
using EventManagement.Domain.Entities.Projects;
using EventManagement.Domain.Interfaces.Repositories;
using EventManagement.Domain.Interfaces.UOW;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Application.Features.Projects.Commands.UpdateProject
{
    public sealed class UpdateProjectCommandHandler:IRequestHandler<UpdateProjectCommand,Guid>
    {
        private IProjectRepository _projectRepository;
        private IUnitOfWork _unitOfWork;
        public UpdateProjectCommandHandler(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetById(request.ProjectId);
            if (project == null)
            {
                throw new NotFoundException(nameof(Project),request.ProjectId);
            }
            project.Name=request.Name;
            project.Description=request.Description;
            project.Completed = request.IsCompleted;
            _projectRepository.Update(project);
            await _unitOfWork.Save();
            return project.Id;
        }
    }
}
