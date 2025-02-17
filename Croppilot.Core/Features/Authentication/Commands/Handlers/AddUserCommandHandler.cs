using Croppilot.Core.Features.Authentication.Commands.Models;
using Croppilot.Date.Identity;
using Croppilot.Infrastructure.Comman;
using IAuthorizationService = Croppilot.Services.Abstract.IAuthorizationService;

namespace Croppilot.Core.Features.Authentication.Commands.Handlers;

public class AddUserCommandHandler(
    IAuthenticationService service,
    IEmailService emailService,
    IUserService userService,
    IAuthorizationService authorizationService)
    : ResponseHandler, IRequestHandler<AddUserCommand, Response<string>>
{
    public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        //// Check if email is already in use
        //if (await userService.GetUserByEmail(request.Email) is not null)
        //{
        //    var errors = new List<Error>
        //    {
        //        new Error
        //        {
        //            Code = "UniqueEmail",
        //            Message = "Email must be unique",
        //            Field = "Email"
        //        }
        //    };
        //    return BadRequest<string>(errors, "Validation error");
        //}

        // Check if username is already in use
        //if (await userService.GetUserByUserName(request.UserName) is not null)
        //{
        //    var errors = new List<Error>
        //    {
        //        new Error
        //        {
        //            Code = "UniqueUserName",
        //            Message = "UserName must be unique",
        //            Field = "UserName"
        //        }
        //    };
        //    return BadRequest<string>(errors, "Validation error");
        //}

        var user = request.Adapt<ApplicationUser>();

        var result = await service.CreateUserAsync(user, request.Password);
        if (!result.Succeeded)
        {
            return BadRequest<string>(result.Errors.FirstOrDefault()?.Description ?? "User creation failed");
        }

        // Assign the default user role
        await authorizationService.AssignRolesToUser(user, [SD.UserRole]);

        // Send confirmation email

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