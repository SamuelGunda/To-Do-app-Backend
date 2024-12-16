using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using To_Do_app_Backend.Exceptions;

namespace To_Do_app_Backend.Middleware;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        
        Console.WriteLine($"Exception caught by GlobalExceptionHandler: {exception.Message}");

        var problemDetails = exception switch
        {
            EntityAlreadyExistsException entityAlreadyExistsException => new ProblemDetails
            {
                Status = StatusCodes.Status409Conflict,
                Title = "Entity already exists",
                Detail = entityAlreadyExistsException.Message
            },
            EntityNotFoundException entityNotFoundException => new ProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Title = "Not found",
                Detail = entityNotFoundException.Message
            },
            InvalidLoginException => new ProblemDetails
            {
                Status = StatusCodes.Status401Unauthorized,
                Title = "Invalid login",
                Detail = "Invalid email or password"
            },
            _ => new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Internal server error",
                Detail = "An unexpected error occurred. Please try again later."
            }
        };

        if (problemDetails.Status != null)
        {
            httpContext.Response.StatusCode = problemDetails.Status.Value;
        }

        await httpContext.Response
            .WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}