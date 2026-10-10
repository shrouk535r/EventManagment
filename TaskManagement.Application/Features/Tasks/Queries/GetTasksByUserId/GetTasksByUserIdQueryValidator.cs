using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Tasks.Queries.GetTasksByUserId
{
    public class GetTasksByUserIdQueryValidator:AbstractValidator<GetTasksByUserIdQuery>
    {
        public GetTasksByUserIdQueryValidator()
        {
            RuleFor(t => t.userId).NotEmpty().WithMessage("this field is required");

        }
    }
}
