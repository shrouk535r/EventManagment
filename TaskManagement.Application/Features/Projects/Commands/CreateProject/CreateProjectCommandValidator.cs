using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Projects.Commands.CreateProject
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator() 
        {
            RuleFor(P => P.Name).NotEmpty().WithMessage("Please Enter Project Name")
                .MaximumLength(200).WithMessage("Title Must be less than 200 character");
            
            RuleFor(P => P.UserId).NotEmpty().WithMessage("must Login First to Create Project");
        }
    }
}
