namespace Croppilot.Core.Features.Authorization.Commands.Models
{
	public class AssignRolesToUserCommand : IRequest<Response<string>>
	{
		public string UserName { get; set; }
		public List<string> Roles { get; set; }
	}
}
