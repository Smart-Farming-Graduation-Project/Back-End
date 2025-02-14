using Croppilot.Core.Features.WishLists.Query.Result;
using Croppilot.Date.Models;

namespace Croppilot.Core.Mapping.Wishlists;

public class WishlistQueryMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Wishlist, GetWishlistResponse>()
            .Map(dest => dest.WishlistId, src => src.Id)
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt)
            .Map(dest => dest.UpdatedAt, src => src.UpdatedAt)
            .Map(dest => dest.WishlistItems, src => src.WishlistItems.Adapt<List<GetWishlistItemResponse>>());

        config.NewConfig<WishlistItem, GetWishlistItemResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.ProductId, src => src.ProductId)
            .Map(dest => dest.ProductName, src => src.Product.Name)
            .Map(dest => dest.ProductPrice, src => src.Product.Price);
    }
}