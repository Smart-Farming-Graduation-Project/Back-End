using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;

namespace Croppilot.Core.Exceptions;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlerMiddleware> _logger;

    public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            _logger.LogError(error, "An unhandled exception occurred.");

            var response = context.Response;
            response.ContentType = "application/json";

            var responseModel = new Response<string>
            {
                Succeeded = false,
                Message = GetFullErrorMessage(error),
                StatusCode = GetStatusCode(error)
            };

            response.StatusCode = (int)responseModel.StatusCode;
            await response.WriteAsync(JsonSerializer.Serialize(responseModel));
        }
    }

    private static string GetFullErrorMessage(Exception error)
    {
        return error.InnerException != null
            ? $"{error.Message}\n{error.InnerException.Message}"
            : error.Message;
    }

    private static HttpStatusCode GetStatusCode(Exception error)
    {
        return error switch
        {
            UnauthorizedAccessException => HttpStatusCode.Unauthorized,
            ValidationException => HttpStatusCode.UnprocessableEntity,
            KeyNotFoundException => HttpStatusCode.NotFound,
            DbUpdateException => HttpStatusCode.BadRequest,
            _ => HttpStatusCode.InternalServerError
        };
    }
}
