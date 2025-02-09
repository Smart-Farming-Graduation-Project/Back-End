namespace Croppilot.Core.Mapping.User
{
	public partial class UserMapping
	{
		public void Register(TypeAdapterConfig config)
		{
			GetUserAsignedToRoleMapping(config);
			GetUserMapping(config);
		}
	}
}
