using System.Net;

namespace Croppilot.Core.Bases;

public class ResponseHandler
{
    public Response<T> Success<T>(T entity, string? message = null, Dictionary<string, object>? meta = null)
    {
        return new Response<T>
        {
            Data = entity,
            StatusCode = HttpStatusCode.OK,
            Succeeded = true,
            Message = message ?? "Operation completed successfully",
            Meta = meta
        };
    }

    public Response<T> Created<T>(T entity, string? message = null, Dictionary<string, object>? meta = null)
    {
        return new Response<T>
        {
            Data = entity,
            StatusCode = HttpStatusCode.Created,
            Succeeded = true,
            Message = message ?? "Resource created successfully",
            Meta = meta
        };
    }

    public Response<T> Deleted<T>(string? message = null)
    {
        return new Response<T>
        {
            StatusCode = HttpStatusCode.OK,
            Succeeded = true,
            Message = message ?? "Resource deleted successfully"
        };
    }

    public Response<T> NotFound<T>(string? message = null)
    {
        return new Response<T>
        {
            StatusCode = HttpStatusCode.NotFound,
            Succeeded = false,
            Message = message ?? "Resource not found"
        };
    }

    public Response<T> BadRequest<T>(string? message = null)
    {
        return new Response<T>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Succeeded = false,
            Message = message ?? "Invalid request"
        };
    }

    public Response<T> Unauthorized<T>()
    {
        return new Response<T>()
        {
            StatusCode = HttpStatusCode.Unauthorized,
            Succeeded = false, //todo: i think it should be false because Unauthorized requests should not be marked as successful.
            Message = "You Are Unauthorized"
        };
    }

    public Response<T> Forbidden<T>(string? message = null)
    {
        return new Response<T>
        {
            StatusCode = HttpStatusCode.Forbidden,
            Succeeded = false,
            Message = message ?? "Access forbidden"
        };
    }

    public Response<T> UnprocessableEntity<T>(string? message = null)
    {
        return new Response<T>
        {
            StatusCode = HttpStatusCode.UnprocessableEntity,
            Succeeded = false,
            Message = message ?? "Validation failed"
        };
    }

    public Response<T> InternalError<T>(string? message = null)
    {
        return new Response<T>
        {
            StatusCode = HttpStatusCode.InternalServerError,
            Succeeded = false,
            Message = message ?? "An internal error occurred"
        };
    }

    public Response<T> Conflict<T>(string? message = null)
    {
        return new Response<T>
        {
            StatusCode = HttpStatusCode.Conflict,
            Succeeded = false,
            Message = message ?? "Resource conflict"
        };
    }

    public Response<T> NoContent<T>(string? message = null)
    {
        return new Response<T>
        {
            StatusCode = HttpStatusCode.NoContent,
            Succeeded = true,
            Message = message ?? "No content"
        };
    }
}