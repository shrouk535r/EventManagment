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

namespace TaskManagement.Application.Features.Tasks.Queries.GetTasks
{
    public sealed class GetTasksQueryHandler:IRequestHandler<GetTasksQuery,List<TaskDto>>
    {
        private readonly ITaskRepository _taskRepository;


        public GetTasksQueryHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<TaskDto>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetTasks();
            if (tasks == null)
                throw new NotFoundException("there are No Tasks Added Yet");
            return tasks.Select(task => new TaskDto(
                task.Id,
                task.Title,
                task.Priority,
                task.Status,
                task.Project.Name)).ToList();

        }
    }
}
