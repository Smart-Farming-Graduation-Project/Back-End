namespace Croppilot.Core.Features.User.Commands.Models
{
	public class RemoveUserFromRoleCommand : IRequest<Response<string>>
	{
		public string UserName { get; set; }
		public string RoleName { get; set; }
	}
}
