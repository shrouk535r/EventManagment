using TaskManagement.Application.Excepitions;
using TaskManagement.Application.Features.Auth.Services.Interfaces;
using TaskManagement.Domain.Entities.Users;
using TaskManagement.Domain.Interfaces.UOW;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Auth.Commands.Login
{
    public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponseDTO>
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJWTService _jWTService;
        public LoginCommandHandler(UserManager<User> userManager, IUnitOfWork unitOfWork, IJWTService jWTService)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _jWTService = jWTService;
        }

        public async Task<LoginResponseDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                throw new BadRequestException("Invalid email or password");
            if (!await _userManager.CheckPasswordAsync(user, request.Password))
                throw new BadRequestException("Invalid email or password");
            var token = _jWTService.GenerateToken(user);
            return new LoginResponseDTO(token, user.Role.ToString(), user.Id);
        }
    }
}
