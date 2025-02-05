using System.Net;

namespace Croppilot.Core.Bases;

public class Response<T>
{
    public HttpStatusCode StatusCode { get; set; }
    public bool Succeeded { get; set; }
    public string Message { get; set; }
    public T? Data { get; set; }
    public Dictionary<string, object>? Meta { get; set; }
    public List<Error> Errors { get; set; } = new();

    //public Dictionary<string, List<string>> ErrorsBag { get; set; }

    public Response()
    {
    }

    public Response(T data, string? message = null)
    {
        Succeeded = true;
        Message = message;
        Data = data;
    }

    public Response(string? message)
    {
        Succeeded = false;
        Message = message;
    }

    public Response(string? message, bool succeeded)
    {
        Succeeded = succeeded;
        Message = message;
    }
}