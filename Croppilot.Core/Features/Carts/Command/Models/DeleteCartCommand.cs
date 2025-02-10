namespace Croppilot.Core.Features.Carts.Command.Models;

public record DeleteCartCommand(int CartId) : IRequest<Response<string>>;