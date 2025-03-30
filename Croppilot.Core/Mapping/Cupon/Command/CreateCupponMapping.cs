using Croppilot.Core.Features.Cupon.Command.Models;

namespace Croppilot.Core.Mapping.Cupon
{
	internal partial class CuponMapping
	{
		void CreateCupnMapping(TypeAdapterConfig config)
		{
			config.NewConfig<CreateCuponCommand, Date.Models.Cupon>()
				.Map(dest => dest.Code, src => src.CuponCode)
				.Map(dest => dest.Discount_Type, src => src.DiscountType)
				.Map(dest => dest.Discount_Value, src => src.DiscountValue)
				.Map(dest => dest.ExpirationDate, src => src.ExpirationDate)
				.Map(dest => dest.UsageLimit, src => src.UsageLimit);
		}
	}
}
