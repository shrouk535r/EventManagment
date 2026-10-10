using TaskManagement.Application.Features.Comments.Commands.CreateComment;
using TaskManagement.Application.Features.Comments.Queries.GetCommentsByTaskId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static TaskManagement.Api.Requests.Comments.CommentRequest;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController(IMediator mediator) : ControllerBase
    {
        // GET: api/<CommentController>
        [HttpGet("CommentsByTask/{taskId}")]
        public async Task<IActionResult> Get(Guid taskId)
        {
            var result = await mediator.Send(new GetCommentsByTaskIdQuery(taskId));
            return Ok(result);
        }


        // POST api/<CommentController>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCommentRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await mediator.Send(new CreateCommentCommand(request.Content,request.TaskId,userId));
            return Ok(new
            {
                Message = "Comment Added Successfully!",
                Data = result
            });

        }


    }
}
