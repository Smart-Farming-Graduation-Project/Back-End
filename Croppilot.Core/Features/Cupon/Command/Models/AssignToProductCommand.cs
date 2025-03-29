namespace Croppilot.Core.Features.Cupon.Command.Models
{
	public class AssignToProductCommand : IRequest<Response<string>>
	{
		public int CuponId { get; set; }
		public int ProductId { get; set; }
	}
}
