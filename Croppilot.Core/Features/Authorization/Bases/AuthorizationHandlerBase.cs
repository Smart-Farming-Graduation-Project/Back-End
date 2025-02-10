using Croppilot.Services.Abstract;

namespace Croppilot.Core.Features.Authorization.Bases
{
	internal class AuthorizationHandlerBase : ResponseHandler
	{
		protected IAuthorizationService _service;
		public AuthorizationHandlerBase(IAuthorizationService service)
		{
			_service = service;
		}
	}
}
