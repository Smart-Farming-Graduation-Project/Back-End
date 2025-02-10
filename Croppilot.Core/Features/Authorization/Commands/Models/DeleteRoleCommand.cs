namespace Croppilot.Core.Features.Authorization.Commands.Models
{
	public class DeleteRoleCommand : IRequest<Response<string>>
	{
		public string RoleName { get; set; }
	}
}
