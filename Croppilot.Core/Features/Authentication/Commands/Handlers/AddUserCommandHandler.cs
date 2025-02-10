using Croppilot.Core.Features.Authentication.Commands.Models;
using Croppilot.Date.Identity;
using Croppilot.Infrastructure.Comman;
using Croppilot.Services.Abstract;
using IAuthorizationService = Croppilot.Services.Abstract.IAuthorizationService;

namespace Croppilot.Core.Features.Authentication.Commands.Handlers
{
    public class AddUserCommandHandler(IAuthenticationService service, IEmailService emailService, IUserService userService
    , IAuthorizationService authorizationService)
        : ResponseHandler, IRequestHandler<AddUserCommand, Response<string>>
    {
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            if (await userService.GetUserByEmail(request.Email) is not null)
                return BadRequest<string>("Email must be unique");
            if (await userService.GetUserByUserName(request.UserName) is not null)
                return BadRequest<string>("UserName must be unique");

            var user = request.Adapt<ApplicationUser>();

            var result = await service.CreateUserAsync(user, request.Password);
            if (!result.Succeeded) return BadRequest<string>(result.Errors.FirstOrDefault().Description);

            //Assign user role

            await authorizationService.AssignRolesToUser(user, [SD.UserRole]);

            //Send Confirm Email
            try
            {
                if (await emailService.SendConfirmEMailAsync(user))
                {
                    return Created("User Added successfully", "Your account has been created, please confirm your email address");
                }
                return BadRequest<string>("Failed to send email. Please contact admin");

            }
            catch (Exception)
            {
                return BadRequest<string>("Failed to send email. Please contact admin");
            }

        }
    }
}