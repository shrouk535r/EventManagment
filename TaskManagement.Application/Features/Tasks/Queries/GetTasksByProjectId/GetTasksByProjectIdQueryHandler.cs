using TaskManagement.Application.Excepitions;
using TaskManagement.Application.Features.Tasks.Queries.DTOS;
using TaskManagement.Application.Features.Tasks.Queries.GetTasksByUserId;
using TaskManagement.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Tasks.Queries.GetTasksByProjectId
{
    public sealed class GetTasksByProjectIdQueryHandler:IRequestHandler<GetTasksByProjectIdQuery,List<TaskDto>>
    {
        private readonly ITaskRepository _taskRepository;


        public GetTasksByProjectIdQueryHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<TaskDto>> Handle(GetTasksByProjectIdQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetByProject(request.projectId);
            if (tasks == null)
                throw new NotFoundException(nameof(Domain.Entities.Tasks.Task), request.projectId);
            return tasks.Select(task => new TaskDto(
                task.Id,
                task.Title,
                task.Priority,
                task.Status,
                task.Project.Name)).ToList();

        }
    }
}
