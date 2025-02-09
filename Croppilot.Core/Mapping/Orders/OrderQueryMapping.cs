using Croppilot.Date.Models;

namespace Croppilot.Core.Mapping.Orders;

public class OrderQueryMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Order, GetOrderResponse>()
            .Map(dest => dest.OrderId, src => src.Id)
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.ShippingAddress, src => src.ShippingAddress)
            .Map(dest => dest.Status, src => src.Status.ToString())
            .Map(dest => dest.TotalAmount, src => src.TotalAmount)
            .Map(dest => dest.OrderItems,
                src => src.OrderItems.Adapt<List<GetOrderItemResponse>>());

        config.NewConfig<OrderItem, GetOrderItemResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.ProductId, src => src.ProductId)
            .Map(dest => dest.Quantity, src => src.Quantity)
            .Map(dest => dest.UnitPrice, src => src.UnitPrice);
    }
}