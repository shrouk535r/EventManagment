using EventManagement.Application.Excepitions;
using EventManagement.Domain.Entities.Projects;
using EventManagement.Domain.Entities.Tasks;
using EventManagement.Domain.Interfaces.Repositories;
using EventManagement.Domain.Interfaces.UOW;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Application.Features.Tasks.Commands.UpdateTaskStatus
{
    public sealed class UpdateTaskStatusCommandHandler : IRequestHandler<UpdateTaskStatusCommand, bool>
    {
        private ITaskRepository _taskRepository;
        private IUnitOfWork _unitOfWork;
        public UpdateTaskStatusCommandHandler(ITaskRepository taskRepository, IUnitOfWork unitOfWork)
        {
            _taskRepository = taskRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateTaskStatusCommand request, CancellationToken cancellationToken)
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

            if (!validTransition(task.Status, request.NewStatus))
                throw new ConflictException($"cannot convert from {task.Status} to {request.NewStatus}");
            task.Status = request.NewStatus;
            _taskRepository.Update(task);
            await _unitOfWork.Save();
            return true;
        }
        public bool validTransition(TaskStatusEnum oldstatus,TaskStatusEnum newstaus )
        {
            return oldstatus switch
            {
                TaskStatusEnum.Todo => true,
                TaskStatusEnum.InProgress => newstaus == TaskStatusEnum.InProgress || newstaus == TaskStatusEnum.Completed || newstaus == TaskStatusEnum.Cancelled,
                TaskStatusEnum.Completed => false,
                TaskStatusEnum.Cancelled => false,
            };
        }
    }
}
