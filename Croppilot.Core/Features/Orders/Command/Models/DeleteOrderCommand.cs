namespace Croppilot.Core.Features.Orders.Command.Models;

public record DeleteOrderCommand(int Id) : IRequest<Response<string>>;