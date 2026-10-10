using EventManagement.Api.Requests.Tasks;
using EventManagement.Application.Features.Tasks.Commands.CreateTask;
using EventManagement.Application.Features.Tasks.Commands.DeleteTask;
using EventManagement.Application.Features.Tasks.Commands.UpdateTask;
using EventManagement.Application.Features.Tasks.Commands.UpdateTaskStatus;
using EventManagement.Application.Features.Tasks.Queries.GetTaskById;
using EventManagement.Application.Features.Tasks.Queries.GetTasks;
using EventManagement.Application.Features.Tasks.Queries.GetTasksByProjectId;
using EventManagement.Application.Features.Tasks.Queries.GetTasksByUserId;
using EventManagement.Domain.Entities.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController(IMediator mediator) : ControllerBase
    {
        // GET: api/<TaskController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await mediator.Send(new GetTasksQuery());
            return Ok(result);
        }

        // GET api/<TaskController>/5
        [HttpGet("TasksByProject/{projectId}")]
        public async Task<ActionResult> GetByProject(Guid projectId)
        {
            var result = await mediator.Send(new GetTasksByProjectIdQuery(projectId));
            return result is null ? NotFound() : Ok(result);

        }
        [HttpGet("TasksByUser/{userId}")]
        public async Task<ActionResult> GetByUser(Guid userId)
        {
            var result = await mediator.Send(new GetTasksByUserIdQuery(userId));
            return result is null ? NotFound() : Ok(result);

        }
        [HttpGet("TasksById/{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var result = await mediator.Send(new GetTaskByIdQuery(id));
            return result is null ? NotFound() : Ok(result);

        }
        // POST api/<TaskController>
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(CreateTaskRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await mediator.Send(new CreateTaskCommand(
                request.Title,
                request.Description,
                request.Priority,
                request.DueDate,
                request.ProjectId,
                userId));

            return Ok(new
            {
                Message = "Task Added Successfully!",
                Data = result
            });
        }

        // PUT api/<TaskController>/5
        [Authorize]
        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(Guid id, UpdateTaskRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await mediator.Send(new UpdateTaskCommand(
                id,
                request.Title,
                request.Description,
                request.Priority,
                request.DueDate,
                userId));

            return Ok(new
            {
                Message = "Task Updated Successfully!",
                Data = result
            });
        }
        [Authorize]
        [HttpPut("UpdateStatus/{id}")]
        public async Task<ActionResult> UpdateStatus(Guid id, TaskStatusEnum newStatus)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await mediator.Send(new UpdateTaskStatusCommand(id, newStatus, userId));
            return Ok(new
            {
                Message = $"Task Status Updated Successfully To {newStatus}!",
                Data = result
            });
        }

        // DELETE api/<TaskController>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await mediator.Send(new DeleteTaskCommand(id));
            return Ok("Task Deleted Successfully!");
        }
    }
}
