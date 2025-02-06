using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

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
        logger.LogError(
            exception,
            "Unhandled exception occurred. Trace ID: {TraceId}, Request Path: {Path}",
            traceId,
            httpContext.Request.Path);

        var statusCode = GetStatusCode(exception);
        var problemDetails = CreateProblemDetails(
            exception,
            statusCode,
            traceId,
            httpContext);

        httpContext.Response.StatusCode = statusCode;
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
        UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
        KeyNotFoundException => StatusCodes.Status404NotFound,
        DbUpdateConcurrencyException => StatusCodes.Status409Conflict,
        DbUpdateException => StatusCodes.Status500InternalServerError,
        NotImplementedException => StatusCodes.Status501NotImplemented,
        _ => StatusCodes.Status500InternalServerError
    };

    private ProblemDetails CreateProblemDetails(
        Exception exception,
        int statusCode,
        string traceId,
        HttpContext httpContext)
    {
        return new ProblemDetails
        {
            Status = statusCode,
            Title = GetTitle(exception),
            Type = "https://tools.ietf.org/html/rfc7231#" + statusCode,
            Instance = httpContext.Request.Path,
            Extensions =
            {
                ["traceId"] = traceId,
                ["requestId"] = httpContext.Connection.Id,
                ["timestamp"] = DateTimeOffset.UtcNow.ToString("O")
            }
        };
    }

    private static string GetTitle(Exception exception) => exception switch
    {
        BadHttpRequestException => "Invalid Request",
        UnauthorizedAccessException => "Unauthorized",
        KeyNotFoundException => "Resource Not Found",
        DbUpdateConcurrencyException => "Concurrency Conflict",
        DbUpdateException => "Database Error",
        NotImplementedException => "Not Implemented",
        _ => "Internal Server Error"
    };
}