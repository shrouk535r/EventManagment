using TaskManagement.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Auth.Services.Interfaces
{
    public interface IJWTService
    {
        string  GenerateToken(User user);
    }
}
