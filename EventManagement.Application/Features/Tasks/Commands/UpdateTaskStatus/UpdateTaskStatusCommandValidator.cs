using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Application.Features.Tasks.Commands.UpdateTaskStatus
{
    public class UpdateTaskStatusCommandValidator : AbstractValidator<UpdateTaskStatusCommand>
    {
        public UpdateTaskStatusCommandValidator()
        {
            RuleFor(T => T.TaskId).NotEmpty().WithMessage("Task Id Field is Required");
            RuleFor(T => T.NewStatus).IsInEnum().WithMessage("Invalid Task status");
            RuleFor(P => P.userId).NotEmpty().WithMessage("You Must Login To Update The Task");


        }
    }
}
