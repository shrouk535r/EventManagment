using TaskManagement.Application.Excepitions;
using TaskManagement.Application.Features.Tasks.Queries.DTOS;
using TaskManagement.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Tasks.Queries.GetTaskById
{
    public sealed class GetTaskByIdQueryHandler:IRequestHandler<GetTaskByIdQuery,TaskDetailsDto>
    {
        private readonly ITaskRepository _taskRepository;


        public GetTaskByIdQueryHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<TaskDetailsDto> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetById(request.id);
            if (task == null)
                throw new NotFoundException(nameof(Domain.Entities.Tasks.Task), request.id);
            return new TaskDetailsDto(task.Id,
                DateOnly.FromDateTime(task.CreatedAt),
                DateOnly.FromDateTime(task.UpdatedAt),
                task.Title,
                task.Description,
                task.Priority,
                task.Status,
                task.DueDate,
                task.Project.Name,
                task.Comments?.Select(c => c.Content).ToList() ?? new List<string>());
        }
    }
}
