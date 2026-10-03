using EventManagement.Domain.Entities.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Application.Features.Auth.Commands.Register
{
    public sealed record RegisterCommand(string Name, string Email, string Password, string City, UserRole Role) :IRequest<Guid>;
}
