using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandValidator:AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(T => T.Title).NotEmpty().WithMessage("Please Enter Task Title")
                           .MaximumLength(200).WithMessage("Title Must be less than 200 character");
            RuleFor(T => T.ProjectId).NotEmpty().WithMessage("must Create Project First to Create Task");
            RuleFor(T => T.TaskPriority).IsInEnum().WithMessage("Invalid Task priority");
        }
    }
}
