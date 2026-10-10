using TaskManagement.Application.Excepitions;
using TaskManagement.Application.Features.Projects.Commands.DeleteProject;
using TaskManagement.Domain.Entities.Projects;
using TaskManagement.Domain.Interfaces.Repositories;
using TaskManagement.Domain.Interfaces.UOW;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskManagement.Application.Features.Projects.Commands.UpdateProject
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
            if (!Guid.TryParse(request.userId, out var userId))
                throw new ConflictException("id cannot convert to Guid");

            if (project.UserId != userId)
                throw new ForbiddenException("Update this Project, Owner only can update it");

            project.Name=request.Name;
            project.Description=request.Description;
            project.Completed = request.IsCompleted;
            _projectRepository.Update(project);
            await _unitOfWork.Save();
            return project.Id;
        }
    }
}
