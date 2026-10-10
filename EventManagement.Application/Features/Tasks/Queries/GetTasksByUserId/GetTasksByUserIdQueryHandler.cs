using EventManagement.Application.Excepitions;
using EventManagement.Application.Features.Projects.Queries.DTOS;
using EventManagement.Application.Features.Projects.Queries.GetProjectById;
using EventManagement.Application.Features.Tasks.Queries.DTOS;
using EventManagement.Domain.Entities.Projects;
using EventManagement.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Application.Features.Tasks.Queries.GetTasksByUserId
{
    public sealed class GetTasksByUserIdQueryHandler : IRequestHandler<GetTasksByUserIdQuery, List<TaskDto>>
    {
        private readonly ITaskRepository _taskRepository;

        
        public GetTasksByUserIdQueryHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<TaskDto>> Handle(GetTasksByUserIdQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetByUser(request.userId);
            if (tasks == null)
                throw new NotFoundException(nameof(Domain.Entities.Tasks.Task), request.userId);
            return tasks.Select(task => new TaskDto(
                task.Id,
                task.Title,
                task.Priority,
                task.Status,
                task.Project.Name)).ToList();

        }
    }
}
