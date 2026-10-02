using EventManagement.Application.Excepitions;
using EventManagement.Domain.Entities.Users;
using EventManagement.Domain.Interfaces.UOW;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Application.Features.Auth.Commands.Register
{
    public sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, Guid>
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        public RegisterCommandHandler(UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            if (_userManager.FindByEmailAsync(request.Email) != null)
                throw new ConflictException("Email Already Exist");
            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Role = request.Role,
                City = request.City
            };
            await _userManager.CreateAsync(user, request.Password);
            await _userManager.AddToRoleAsync(user, request.Role.ToString());
            await _unitOfWork.Save();
            return user.Id; 
        }
    }
}
