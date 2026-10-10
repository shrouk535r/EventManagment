using TaskManagement.Application.Features.Projects.Queries.GetProjectById;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Projects.Queries.GetProjectsByUserId
{
    public class GetProjectByUserIdQueryValidator : AbstractValidator<GetProjectByUserIdQuery>
    {
        public GetProjectByUserIdQueryValidator()
        {
            RuleFor(P => P.userId).NotEmpty().WithMessage("this field is required");
        }
    }
}
