using Croppilot.Core.Features.Authentication.Commands.Models;
using Croppilot.Services.Abstract;

namespace Croppilot.Core.Features.Authentication.Commands.Handlers
{
    internal class ChangeUserPasswordCommandHandler : ResponseHandler, IRequestHandler<ChangeUserPasswordCommand, Response<string>>
    {
        private readonly IAuthenticationService _service;
        private readonly IUserService _userService;
        public ChangeUserPasswordCommandHandler(IAuthenticationService service, IUserService userService)
        {
            _service = service;
            _userService = userService;
        }
        public async Task<Response<string>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserById(request.Id);
            if (user is null) return NotFound<string>("User does not exist");
            var result = await _service.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            if (result.Succeeded) return Success(string.Empty);
            return BadRequest<string>(result.Errors.FirstOrDefault().Description);
        }
    }
}