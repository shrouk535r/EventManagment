using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Application.Features.Projects.Queries.DTOS
{
    public sealed record ProjectDto(
        string Name,
        string Description,
        bool Completed,
        string UserName
        );
    public sealed record ProjectDetailsDto(
        string Name,
        string Description,
        bool Completed,
        string UserName,
        List<string> Tasks
        );
}
