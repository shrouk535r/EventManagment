using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Auth.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(U => U.Email).NotEmpty().WithMessage("Email Field is Required");
            RuleFor(U => U.Password).NotEmpty().WithMessage("Password Field is Required");
        }
    }
}
