using EventManagement.Application.Excepitions;
using EventManagement.Domain.Entities.Projects;
using EventManagement.Domain.Entities.Tasks;
using EventManagement.Domain.Interfaces.Repositories;
using EventManagement.Domain.Interfaces.UOW;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Application.Features.Tasks.Commands.CreateTask
{
    public sealed class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
    {
        private ITaskRepository _taskRepository;
        private IUnitOfWork _unitOfWork;
        private IProjectRepository _projectRepository;  
        public CreateTaskCommandHandler(ITaskRepository taskRepository, IUnitOfWork unitOfWork, IProjectRepository projectRepository) 
        {
            _taskRepository = taskRepository;
            _unitOfWork = unitOfWork;
            _projectRepository = projectRepository;
        }
        public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetById(request.ProjectId);
            if (project == null)
                throw new NotFoundException(nameof(Project), request.ProjectId);
            var newtask = new Domain.Entities.Tasks.Task
            {
                Title = request.Title,
                Description = request.Description,
                Priority = request.TaskPriority,
                DueDate= request.DueDate,
                ProjectId = request.ProjectId
            };
            await _taskRepository.Add(newtask);
            await _unitOfWork.Save();
            return newtask.Id;

        }
    }
}
