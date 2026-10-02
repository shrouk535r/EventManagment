using EventManagement.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Application.Features.Auth.Commands.Login
{
    public sealed record LoginResponseDTO(string Token, UserRole Role, Guid UserId)
}
