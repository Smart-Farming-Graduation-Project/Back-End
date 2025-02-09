namespace Croppilot.Core.Features.Leasing.Command.Model
{
    public record DeleteLeaseCommand(int Id) : IRequest<Response<string>>;

}
