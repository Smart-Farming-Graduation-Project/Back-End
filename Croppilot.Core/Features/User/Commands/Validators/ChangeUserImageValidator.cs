using Croppilot.Core.Features.User.Commands.Models;

namespace Croppilot.Core.Features.User.Commands.Validators
{
	public class ChangeUserImageValidator : AbstractValidator<ChangeUserImageCommand>
	{
		public ChangeUserImageValidator()
		{
			RuleFor(x => x.Image)
				.NotEmpty().WithMessage("Image is required.")
				.Must(x => x.Length > 0).WithMessage("Uploaded image cannot be empty.")
				.Must(x => x.ContentType == "image/jpeg" || x.ContentType == "image/png" ||
				           x.ContentType == "image/jpg")
				.WithMessage("Only JPEG, JPG, and PNG formats are allowed.");
		}
	}
}
