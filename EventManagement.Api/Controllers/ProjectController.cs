using Azure.Core;
using EventManagement.Api.Requests.Projects;
using EventManagement.Application.Features.Projects.Commands.CreateProject;
using EventManagement.Application.Features.Projects.Commands.DeleteProject;
using EventManagement.Application.Features.Projects.Commands.UpdateProject;
using EventManagement.Application.Features.Projects.Queries.GetProjectById;
using EventManagement.Application.Features.Projects.Queries.GetProjects;
using EventManagement.Application.Features.Projects.Queries.GetProjectsByUserId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventManagement.Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController(IMediator mediator) : ControllerBase
    {
        // GET: api/<ProjectController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await mediator.Send(new GetProjectQuery());
            return Ok(result);
        }

        // GET api/<ProjectController>/5
        [HttpGet("GetProjects/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await mediator.Send(new GetProjectByIdQuery(id));
            return result is null ? NotFound() : Ok(result);
        }
        [HttpGet("GetProjectsByUser/{Userid}")]
        public async Task<IActionResult> GetByUserId(Guid Userid)
        {
            var result = await mediator.Send(new GetProjectByUserIdQuery(Userid));
            return result is null ? NotFound() : Ok(result);

        }
        [Authorize]
        // POST api/<ProjectController>
        [HttpPost("CreateProject")]
        public async Task<IActionResult> create(CreateProjectRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var command = new CreateProjectCommand(request.Name, request.Description, userId);
            var result = await mediator.Send(command);
            return Ok(new
            {
                Message = "Project Added Successfully!",
                Data = result
            });

        }

        // PUT api/<ProjectController>/5
        [Authorize]
        [HttpPut("UpdateProject/{id}")]
        public async Task<IActionResult> UpdateProject(Guid id, UpdateProjectRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var command = new UpdateProjectCommand(id, request.Name, request.Description, request.IsCompleted,userId);
            var result = await mediator.Send(command);
            return Ok(new
            {
                Message = "Project Updated Successfully!",
                Data = result
            });

        }

        // DELETE api/<ProjectController>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteProject/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            var command = new DeleteProjectCommand(id);
            var result = await mediator.Send(command);
            return Ok("Project Deleted Successfully!");

        }
    }
}
