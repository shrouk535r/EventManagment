using EventManagement.Application.Excepitions;
using EventManagement.Application.Features.Tasks.Commands.DeleteTask;
using EventManagement.Domain.Entities.Tasks;
using EventManagement.Domain.Interfaces.Repositories;
using EventManagement.Domain.Interfaces.UOW;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Application.Features.Tasks.Commands.DeleteTask
{
    public sealed class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, bool>
    {
        private ITaskRepository _taskRepository;
        private IUnitOfWork _unitOfWork;
        public DeleteTaskCommandHandler(ITaskRepository taskRepository, IUnitOfWork unitOfWork)
        {
            _taskRepository = taskRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetById(request.id);
            if (task == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Tasks.Task), request.id);
            }
            _taskRepository.Delete(task);
            await _unitOfWork.Save();
            return true;
        }
    }
}
