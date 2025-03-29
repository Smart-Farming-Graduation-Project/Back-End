namespace Croppilot.Core.Features.Cupon.Command.Models
{
	public class CreateCuponCommand : IRequest<Response<string>>
	{
		public required string CuponCode { get; set; }
		public Discount_Type DiscountType { get; set; }
		public decimal DiscountValue { get; set; }
		public DateTime ExpirationDate { get; set; }
		public int UsageLimit { get; set; }
	}
}
