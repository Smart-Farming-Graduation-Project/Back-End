using Croppilot.Core.Features.Orders.Command.Models;
using Croppilot.Date.Models; 

namespace Croppilot.Core.Mapping.Orders;

public class OrderCommandMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateOrderCommand, Order>()
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.ShippingAddress, src => src.ShippingAddress)
            .Map(dest => dest.OrderItems, src => src.OrderItems.Adapt<List<OrderItem>>())
            .Ignore(dest => dest.Id)
            .Ignore(dest => dest.CreatedAt)
            .Ignore(dest => dest.UpdatedAt);

        config.NewConfig<UpdateOrderCommand, Order>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.ShippingAddress, src => src.ShippingAddress)
            .Map(dest => dest.Status, src => src.Status)
            .Map(dest => dest.UpdatedAt, src => DateTime.UtcNow)
            .Ignore(dest => dest.CreatedAt)
            .Ignore(dest => dest.OrderItems)
            .Ignore(dest => dest.UserId)
            .Ignore(dest => dest.TotalAmount);

        config.NewConfig<DeleteOrderCommand, Order>()
            .Map(dest => dest.Id, src => src.Id)
            .Ignore(dest => dest.UserId)
            .Ignore(dest => dest.ShippingAddress)
            .Ignore(dest => dest.Status)
            .Ignore(dest => dest.TotalAmount)
            .Ignore(dest => dest.CreatedAt)
            .Ignore(dest => dest.UpdatedAt)
            .Ignore(dest => dest.OrderItems);
    }
}