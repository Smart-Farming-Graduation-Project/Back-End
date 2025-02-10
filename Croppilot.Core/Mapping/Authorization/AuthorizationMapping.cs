namespace Croppilot.Core.Mapping.Authorization
{
	internal partial class AuthorizationMapping : IRegister
	{
		public void Register(TypeAdapterConfig config)
		{
			GetRoleMapping(config);
		}
	}
}
