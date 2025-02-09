namespace Croppilot.Core.Features.Leasing.Query.Result
{
    public record GetAllLeasingResult(
        int Id,
        int ProductId,
        DateTime StartingDate,
        string LeasingDetails,
        DateTime EndDate);
}
