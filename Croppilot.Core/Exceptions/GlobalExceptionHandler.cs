using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using System.Text.Json;

namespace Croppilot.Core.Exceptions;

public class GlobalExceptionHandler(
    ILogger<GlobalExceptionHandler> logger,
    IHostEnvironment environment) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var traceId = Activity.Current?.Id ?? httpContext.TraceIdentifier;
        var request = httpContext.Request;

        // Log error with detailed request information
        logger.LogError(exception,
            "Unhandled exception occurred. Trace ID: {TraceId}, Request: {Method} {Path} {Query}, Headers: {Headers}",
            traceId, request.Method, request.Path, request.QueryString, request.Headers);

        if (exception.InnerException != null)
        {
            logger.LogError("Inner Exception: {InnerException}", exception.InnerException);
        }

        var statusCode = GetStatusCode(exception);
        var problemDetails = CreateProblemDetails(exception, statusCode, traceId, httpContext);

        httpContext.Response.StatusCode = statusCode;
        httpContext.Response.ContentType = "application/json";

        await httpContext.Response.WriteAsJsonAsync(
            problemDetails,
            new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase },
            cancellationToken);

        return true;
    }

    private static int GetStatusCode(Exception exception) => exception switch
    {
        BadHttpRequestException => StatusCodes.Status400BadRequest,
        ArgumentException => StatusCodes.Status400BadRequest,
        ValidationException => StatusCodes.Status422UnprocessableEntity,
        UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
        KeyNotFoundException => StatusCodes.Status404NotFound,
        DbUpdateConcurrencyException => StatusCodes.Status409Conflict,
        DbUpdateException => StatusCodes.Status400BadRequest,
        NotImplementedException => StatusCodes.Status501NotImplemented,
        OperationCanceledException => StatusCodes.Status499ClientClosedRequest,
        _ => StatusCodes.Status500InternalServerError
    };

    private ProblemDetails CreateProblemDetails(
        Exception exception,
        int statusCode,
        string traceId,
        HttpContext httpContext)
    {
        var request = httpContext.Request;

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = GetTitle(exception),
            Type = $"https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/{statusCode}",
            Instance = request.Path,
            Extensions =
            {
                ["traceId"] = traceId,
                ["requestId"] = httpContext.Connection.Id,
                ["method"] = request.Method,
                ["timestamp"] = DateTimeOffset.UtcNow.ToString("O"),
                ["user"] = httpContext.User.Identity?.Name ?? "Anonymous"
            }
        };

        if (environment.IsDevelopment())
        {
            problemDetails.Extensions["exception"] = new
            {
                message = exception.Message,
                stackTrace = exception.StackTrace,
                innerException = exception.InnerException?.Message
            };
        }

        return problemDetails;
    }

    private static string GetTitle(Exception exception) => exception switch
    {
        BadHttpRequestException => "Invalid Request",
        ArgumentException => "Invalid Argument",
        ValidationException => "Validation Failed",
        UnauthorizedAccessException => "Unauthorized",
        KeyNotFoundException => "Resource Not Found",
        DbUpdateConcurrencyException => "Concurrency Conflict",
        DbUpdateException => "Database Error",
        NotImplementedException => "Not Implemented",
        OperationCanceledException => "Request Cancelled",
        _ => "Internal Server Error"
    };
}
