using Croppilot.Core.Features.Cupon.Command.Models;
using System.Security.Claims;

namespace Croppilot.Core.Features.Cupon.Command.Handlers
{
	class AssignToProductCommandHandler(IHttpContextAccessor httpContextAccessor
		, ICuponService cuponService
		, IProductServices productServices)
		: ResponseHandler,
		IRequestHandler<AssignToProductCommand, Response<string>>
	{
		public async Task<Response<string>> Handle(AssignToProductCommand request, CancellationToken cancellationToken)
		{
			var userId = httpContextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			if (string.IsNullOrEmpty(userId))
				return NotFound<string>("User not found.");
			var cupon = await cuponService.GetCuponByIdAsync(request.CuponId);
			if (cupon == null)
				return NotFound<string>("Cupon not found.");
			var product = await productServices.GetByIdAsync(request.ProductId, new string[] { "Cupon" });
			if (product == null)
				return NotFound<string>("Product not found.");
			if (product.UserId != userId || cupon.UserId != userId)
				return Unauthorized<string>("You are not authorized to assign cupon to this product.");
			if (product.CuponId is not null && product.Cupon.IsActive)
				return BadRequest<string>("Product already has a cupon.");
			if (!cupon.IsActive)
				return BadRequest<string>("Cupon is not active.");
			product.CuponId = cupon.Id;
			var result = await productServices.UpdateAsync(product) == OperationResult.Success
				? Success<string>("Cupon assigned to product successfully.")
				: BadRequest<string>("Failed to assign cupon to product.");
			return result;

		}
	}
}
