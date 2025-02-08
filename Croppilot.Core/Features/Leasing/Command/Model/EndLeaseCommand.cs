namespace Croppilot.Core.Features.Leasing.Command.Model
{
    public record EndLeaseCommand(int Id, DateTime EndDate) : IRequest<Response<string>>;

}
