using Croppilot.Date.Models;

namespace Croppilot.Core.Mapping.Carts;

public class CartQueryMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Cart, GetCartResponse>()
            .Map(dest => dest.CartId, src => src.Id)
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt)
            .Map(dest => dest.UpdatedAt, src => src.UpdatedAt)
            .Map(dest => dest.CartItems, src => src.CartItems.Adapt<List<GetCartItemResponse>>());

        config.NewConfig<CartItem, GetCartItemResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.ProductId, src => src.ProductId)
            .Map(dest => dest.ProductName, src => src.Product.Name)
            .Map(dest => dest.ProductPrice, src => src.Product.Price)
            .Map(dest => dest.Quantity, src => src.Quantity);
    }
}