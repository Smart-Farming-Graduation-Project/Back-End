namespace Croppilot.Core.Features.Leasing.Command.Model
{
    public record LeaseProductCommand(int ProductId, DateTime StartingDate, string LeasingDetails) : IRequest<Response<string>>;

}
