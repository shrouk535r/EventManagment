using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Application.Features.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommandValidator:AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator() 
        {
            RuleFor(P => P.ProjectId).NotEmpty().WithMessage("Project Id Field is required");
            RuleFor(P => P.Name).NotEmpty().WithMessage("Please Enter Project Name")
               .MaximumLength(200).WithMessage("Title Must be less than 200 character");
            RuleFor(P => P.userId).NotEmpty().WithMessage("You Must Login To Update The Project");

        }
    }
}
