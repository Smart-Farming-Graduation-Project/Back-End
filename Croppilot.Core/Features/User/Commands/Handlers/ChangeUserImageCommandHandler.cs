using Croppilot.Core.Features.User.Commands.Models;
using System.Security.Claims;

namespace Croppilot.Core.Features.User.Commands.Handlers
{
	class ChangeUserImageCommandHandler(IHttpContextAccessor httpContextAccessor,
		IUserService userService,
		IAzureBlobStorageService azureBlobStorageService)
		: ResponseHandler, IRequestHandler<ChangeUserImageCommand, Response<string>>
	{
		public async Task<Response<string>> Handle(ChangeUserImageCommand request, CancellationToken cancellationToken)
		{
			var userId = httpContextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			var user = await userService.GetUserById(userId);
			if (user is null)
			{
				return NotFound<string>("User not found");
			}
			var oldimageUrl = user.ImageUrl;
			if (!string.IsNullOrEmpty(oldimageUrl))
			{
				var oldimagePath = oldimageUrl?.Split('/').Last();
				await azureBlobStorageService.DeleteImageAsync(oldimagePath, "user-images");
			}
			var newImageUrl = await azureBlobStorageService.UploadImageAsync(request.Image.OpenReadStream(),
				"user-images",
				$"{Guid.NewGuid().ToString()}_{user.UserName}{Path.GetExtension(request.Image.FileName)}");
			user.ImageUrl = newImageUrl;
			var result = await userService.UpdateUserAsync(user);
			return result.Succeeded
				? Success("User image updated successfully")
				: BadRequest<string>("Failed to update user image");
		}
	}
}
