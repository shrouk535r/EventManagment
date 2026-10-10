using EventManagement.Application.Excepitions;
using EventManagement.Domain.Entities.Projects;
using EventManagement.Domain.Entities.Users;
using EventManagement.Domain.Interfaces.Repositories;
using EventManagement.Domain.Interfaces.UOW;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Application.Features.Projects.Commands.CreateProject
{
    public sealed class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Guid>
    {
        private IProjectRepository _projectRepository;
        private IUnitOfWork _unitOfWork;
        public CreateProjectCommandHandler(IProjectRepository projectRepository,IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.UserId, out var userId))
                throw new ConflictException("id cannot convert to Guid");

            var newproject = new Project
            {
                Name = request.Name,
                Description = request.Description,
                UserId = userId,
                Completed = false,
            };
            await _projectRepository.Add(newproject);
            await _unitOfWork.Save();
            return newproject.Id;
        }
    }
}
