using EventManagement.Api.Requests.Auth;
using EventManagement.Application.Features.Auth.Commands.Login;
using EventManagement.Application.Features.Auth.Commands.Register;
using EventManagement.Domain.Entities.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMediator mediator, SignInManager<User> signInManager) : ControllerBase
    {
        // GET: api/<AuthController>
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(request.Name, request.Email,request.Password, request.City,request.Role);
            var result = await mediator.Send(command);
            return Ok(new
            {
                Message ="Registerd Successfully",
                Data = result
            });
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var command = new LoginCommand(request.Email, request.Password);
            var result = await mediator.Send(command);
            return Ok(new
            {
                Message = "Logined Successfully",
                Data = result
            });
        }
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok(); 
        }

    }
}
