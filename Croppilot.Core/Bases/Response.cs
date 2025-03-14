using System.Net;
using System.Text.Json.Serialization;

namespace Croppilot.Core.Bases;

public class Response<T>
{
    [JsonConverter(typeof(HttpStatusCodeConverter))]
    public HttpStatusCode StatusCode { get; set; }
    public bool Succeeded { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }
    public Dictionary<string, object>? Meta { get; set; }
    //  public object Errors { get; set; } = new();

    //public Dictionary<string, List<string>> ErrorsBag { get; set; }

    public Response()
    {
    }

    public Response(T data, string? message = null)
    {
        Succeeded = true;
        Message = message ?? string.Empty;
        Data = data;
    }

    public Response(string? message)
    {
        Succeeded = false;
        Message = message ?? string.Empty;
    }

    public Response(string? message, bool succeeded)
    {
        Succeeded = succeeded;
        Message = message ?? string.Empty;
    }
}
