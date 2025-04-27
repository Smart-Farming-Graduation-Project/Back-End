using Croppilot.Core.Features.User.Commands.Models;

namespace Croppilot.Core.Features.User.Commands.Handlers
{
	internal class DeleteUserCommandHandler(IUserService service, IAzureBlobStorageService azureBlobStorageService)
		: ResponseHandler, IRequestHandler<DeleteUserCommand, Response<string>>
	{
		public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
		{
			var user = await service.GetUserById(request.Id);
			if (user is null) return NotFound<string>("User does not exist");
			var ImageUrl = user.ImageUrl;
			if (!string.IsNullOrEmpty(ImageUrl))
			{
				var blobName = ImageUrl?.Split('/').Last();
				await azureBlobStorageService.DeleteImageAsync(blobName, "user-images");
			}
			var result = await service.DeleteUserAsync(user);
			if (result.Succeeded) return Success("User Deleted");
			return BadRequest<string>("Failed to delete user");
		}
	}
}
