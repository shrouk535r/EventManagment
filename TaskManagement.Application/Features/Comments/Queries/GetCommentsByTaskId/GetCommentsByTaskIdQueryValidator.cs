using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Comments.Queries.GetCommentsByTaskId
{
    public class GetCommentsByTaskIdQueryValidator:AbstractValidator<GetCommentsByTaskIdQuery>
    {
        public GetCommentsByTaskIdQueryValidator()
        {
            RuleFor(c => c.taskId).NotEmpty().WithMessage("This Field is required.");
        }
    }
}
