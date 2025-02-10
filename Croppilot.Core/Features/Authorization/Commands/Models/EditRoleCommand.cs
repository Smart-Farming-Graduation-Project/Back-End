namespace Croppilot.Core.Features.Authorization.Commands.Models
{
	public class EditRoleCommand : IRequest<Response<string>>
	{
		public string CurrentName { get; set; }
		public string NewName { get; set; }
	}
}
