using TaskManagement.Application.Excepitions;
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

namespace TaskManagement.Application.Features.Projects.Commands.DeleteProject
{
    public sealed class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, bool>
    {
        private IProjectRepository _projectRepository;
        private IUnitOfWork _unitOfWork;
        public DeleteProjectCommandHandler(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
        {
            _projectRepository= projectRepository;
            _unitOfWork= unitOfWork; 
        }

        public async Task<bool> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetById(request.ProjectId);
            if (project == null)
            {
                throw new NotFoundException(nameof(Project), request.ProjectId);
            }
           
            _projectRepository.Delete(project);
            await _unitOfWork.Save();
            return true;
        }
    }
}
