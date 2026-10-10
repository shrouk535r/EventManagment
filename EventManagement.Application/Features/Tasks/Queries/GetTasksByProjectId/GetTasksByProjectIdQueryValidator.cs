using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Application.Features.Tasks.Queries.GetTasksByProjectId
{
    public class GetTasksByProjectIdQueryValidator:AbstractValidator<GetTasksByProjectIdQuery>
    {
        public GetTasksByProjectIdQueryValidator()
        {
            RuleFor(t => t.projectId).NotEmpty().WithMessage("this field is required");

        }
    }
}
