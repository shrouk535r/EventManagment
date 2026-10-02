using EventManagement.Application.Excepitions;
using EventManagement.Application.Features.Tasks.Commands.UpdateTask;
using EventManagement.Domain.Entities.Tasks;
using EventManagement.Domain.Interfaces.Repositories;
using EventManagement.Domain.Interfaces.UOW;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventManagement.Application.Features.Tasks.Commands.UpdateTask
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
