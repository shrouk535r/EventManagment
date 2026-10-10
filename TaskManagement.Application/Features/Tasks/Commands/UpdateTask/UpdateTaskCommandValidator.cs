using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
    {
        public UpdateTaskCommandValidator()
        {
            RuleFor(T => T.TaskId).NotEmpty().WithMessage("Task Id Field is required");
            RuleFor(T => T.Title).NotEmpty().WithMessage("Please Enter Title Name")
               .MaximumLength(200).WithMessage("Title Must be less than 200 character");
            RuleFor(T => T.TaskPriority).IsInEnum().WithMessage("Invalid Task priority");
            RuleFor(P => P.userId).NotEmpty().WithMessage("You Must Login To Update The Task");

        }
    }
}
