using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Projects.Queries.DTOS
{
    public sealed record ProjectDto(
        Guid projectId,
        string Name,
        string Description,
        bool Completed,
        string UserName
        );
    public sealed record ProjectDetailsDto(
        Guid projectId,
        DateOnly CreatedAt,
        DateOnly UpdatedAt,
        string Name,
        string Description,
        bool Completed,
        string UserName,
        List<string> Tasks
        );
}
