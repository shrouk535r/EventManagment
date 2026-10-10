using TaskManagement.Application.Excepitions;
using TaskManagement.Application.Features.Tasks.Commands.UpdateTask;
using TaskManagement.Domain.Entities.Projects;
using TaskManagement.Domain.Entities.Tasks;
using TaskManagement.Domain.Interfaces.Repositories;
using TaskManagement.Domain.Interfaces.UOW;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskManagement.Application.Features.Tasks.Commands.UpdateTask
{
    public sealed class UpdateTaskCommandHandler:IRequestHandler<UpdateTaskCommand,Guid>
    {
        private ITaskRepository _taskRepository;
        private IUnitOfWork _unitOfWork;
        public UpdateTaskCommandHandler(ITaskRepository taskRepository, IUnitOfWork unitOfWork)
        {
            _taskRepository = taskRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetById(request.TaskId);
            if (task == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Tasks.Task), request.TaskId);
            }
            if (!Guid.TryParse(request.userId, out var userId))
                throw new ConflictException("id cannot convert to Guid");

            if (task.Project.UserId != userId)
                throw new ForbiddenException("Update this Task, Owner only can update it");

            task.Title = request.Title;
            task.Description = request.Description;
            task.Priority = request.TaskPriority;
            task.DueDate= request.DueDate;
            _taskRepository.Update(task);
            await _unitOfWork.Save();
            return task.Id;
        }
    }
}
