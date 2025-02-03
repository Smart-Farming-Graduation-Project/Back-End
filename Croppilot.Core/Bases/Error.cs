namespace Croppilot.Core.Bases;

public class Error
{
    public string Code { get; set; }
    public string Message { get; set; }
    public string? Field { get; set; }
}