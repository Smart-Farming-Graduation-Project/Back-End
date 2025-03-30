using Croppilot.Core.Features.Payment.Command.Model;

namespace Croppilot.Core.Features.Payment.Command.Handler
{
	class CreateCheckOutSessionCommandHandler(IPaymentService paymentService,
		IOrderService orderService)
		: ResponseHandler, IRequestHandler<CreateCheckOutSessionCommand, Response<string>>
	{
		public async Task<Response<string>> Handle(CreateCheckOutSessionCommand request, CancellationToken cancellationToken)
		{
			var order = await orderService.GetByIdAsync(request.OrderId, cancellationToken: cancellationToken);
			if (order is null)
				return NotFound<string>($"Order with ID {request.OrderId} does not exist.");
			if (order.Status != OrderStatus.Pending)
				return BadRequest<string>($"Order with ID {request.OrderId} is not pending.");

			var sessionUrl = paymentService.CreateCheckoutSession(order.Id, order.TotalAmount, request.SuccessUrl, request.CancelUrl);
			return Created<string>(sessionUrl);
		}
	}
}
