using TaskManagement.Application.Excepitions;
using TaskManagement.Domain.Entities.Users;
using TaskManagement.Domain.Interfaces.UOW;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Auth.Commands.Register
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
            if ((await _userManager.FindByEmailAsync(request.Email)) != null)
                throw new ConflictException("Email Already Exist");
            var user = new User
            {
                UserName=request.Email,
                Name = request.Name,
                Email = request.Email,
                Role = request.Role,
                City = request.City
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if(!result.Succeeded)
            {
                var errors = string.Join(
                ", ",
                result.Errors.Select(e => e.Description));
                throw new BadRequestException(errors);
            }
            var roleResult = await _userManager.AddToRoleAsync(user, request.Role.ToString());
            if (!roleResult.Succeeded)
            {
                var errors = string.Join(
                ", ",
                roleResult.Errors.Select(e => e.Description));
                throw new BadRequestException(errors);
            }
            await _unitOfWork.Save();
            return user.Id; 
        }
    }
}
