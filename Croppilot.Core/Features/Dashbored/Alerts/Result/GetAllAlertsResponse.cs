namespace Croppilot.Core.Features.Dashbored.Alerts.Result
{
    public record GetAllAlertsResponse(
        int AlertId,
        string AlertType,
        string Message,
        string Severity,
        double Latitude,
        double Longitude,
        string LocationDescription,
        DateTime CreatedAt
    );
}
