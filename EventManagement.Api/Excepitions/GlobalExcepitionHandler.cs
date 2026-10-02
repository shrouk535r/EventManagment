using EventManagement.Application.Excepitions;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement.Api.Excepitions
{
    public class GlobalExcepitionHandler:IExceptionHandler
    {
        private IProblemDetailsService _problemDetailsService;

        public GlobalExcepitionHandler(IProblemDetailsService problemDetailsService)
        {
            _problemDetailsService = problemDetailsService;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            ProblemDetails problem = exception switch
            {
                ValidationException ex => new ValidationProblemDetails(
                ex.Errors.GroupBy(g => g.PropertyName).ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray())
                )
                {
                    Title ="Validation Falid",
                    Status= StatusCodes.Status400BadRequest
                },
                BadRequestException ex => new ProblemDetails
                {
                    Title = "Bad Request!",
                    Detail = ex.Message,
                    Status = ex.SatusCode
                },
                UnauthorizedException ex => new ProblemDetails
                {
                    Title = "Un Authorized!",
                    Detail = ex.Message,
                    Status = ex.SatusCode
                },
                ForbiddenException ex => new ProblemDetails
                {
                    Title = "Not Forbidden!",
                    Detail = ex.Message,
                    Status = ex.SatusCode
                },
                NotFoundException ex => new ProblemDetails
                {
                    Title = "Not Found!",
                    Detail = ex.Message,
                    Status = ex.SatusCode
                },
                ConflictException ex => new ProblemDetails
                {
                    Title = "Conflict!",
                    Detail = ex.Message,
                    Status = ex.SatusCode
                },
                InternalServerException ex => new ProblemDetails
                {
                    Title = "Internal Server Error!",
                    Detail = ex.Message,
                    Status = ex.SatusCode
                },
                _ =>
                 new ProblemDetails
                 {
                     Title = "Server Error!",
                     Detail = "An unexpected error occurred.",
                     Status = StatusCodes.Status500InternalServerError
                 },
            };
            httpContext.Response.StatusCode = problem.Status!.Value;
            await _problemDetailsService.WriteAsync(new ProblemDetailsContext
            {
                HttpContext= httpContext,
                ProblemDetails= problem
            });
            return true;

        }
    }
}
