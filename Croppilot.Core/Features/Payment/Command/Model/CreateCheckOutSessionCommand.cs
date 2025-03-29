namespace Croppilot.Core.Features.Payment.Command.Model
{
	public class CreateCheckOutSessionCommand : IRequest<Response<string>>
	{
		public int OrderId { get; set; }
		public string SuccessUrl { get; set; }
		public string CancelUrl { get; set; }
	}
}
