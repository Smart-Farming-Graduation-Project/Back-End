namespace Croppilot.Core.Features.User.Queries.Result
{
	public class GetUserRoleResult
	{
		public string UserName { get; set; }
		public List<string> Roles { get; set; } = new List<string>();
	}
}
