using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Application.Features.Comments.Commands.CreateComment
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(C => C.Content).NotEmpty().WithMessage("Content Field is Required");
            RuleFor(C => C.UserId).NotEmpty().WithMessage("You Must Login First to can Comment");
            RuleFor(C => C.Content).NotEmpty().WithMessage("you Must Provide Task want to comment on it");

        }
    }
}
