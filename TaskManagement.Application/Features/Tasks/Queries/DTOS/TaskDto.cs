using TaskManagement.Domain.Entities.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Tasks.Queries.DTOS
{
    public sealed record TaskDto
    (
        Guid TaskId,
        string Title, 
        TaskPriority Priority,
        TaskStatusEnum Status,
        string ProjectName
    );
    public sealed record TaskDetailsDto
    (
        Guid TaskId,
        DateOnly CreatedAt,
        DateOnly UpdatedAT,
        string Title,
        string Description,
        TaskPriority Priority,
        TaskStatusEnum Status,
        DateOnly DueDate,
        string ProjectName,
        List<string> Comments
    );
}
