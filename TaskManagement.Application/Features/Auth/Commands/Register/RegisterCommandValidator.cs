using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(U => U.Name).NotEmpty().WithMessage("Name Field is Required")
                .MaximumLength(200).WithMessage("Name cannot exceed 200 characters.");

            RuleFor(U => U.Email)
                .NotEmpty().WithMessage("Email Field is Required")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(U => U.Password)
                .NotEmpty().WithMessage("Password Field is Required")
                 .MinimumLength(8).WithMessage("Password must be at least 8 characters.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one number."); ;

            RuleFor(U => U.Role).IsInEnum().WithMessage("Role Field not valid");

        }
    }
}
