namespace Croppilot.Core.Features.User.Commands.Models
{
	public class ChangeUserRoleCommand : IRequest<Response<string>>
	{
		public string UserName { get; set; }
		public string RoleName { get; set; }
		public string NewRoleName { get; set; }
	}
}
