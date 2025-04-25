using Croppilot.Core.Features.Authentication.Commands.Models;
using Croppilot.Core.Features.Authentication.Commands.Result;
using Croppilot.Date.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Croppilot.Core.Features.Authentication.Commands.Handlers;

public class SignInCommandHandler(
    IAuthenticationService service,
    IUserService userService)
    : ResponseHandler, IRequestHandler<SignInCommand, Response<SignInResponse>>
{
    public async Task<Response<SignInResponse>> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        //var user = await userService.GetUserByUserName(request.UserName);
        var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        ApplicationUser user = new ApplicationUser();
        if (new EmailAddressAttribute().IsValid(request.UserNameOrEmail))
            user = await userService.GetUserByEmail(request.UserNameOrEmail);
        else
            user = await userService.GetUserByUserName(request.UserNameOrEmail);

        if (user is null)
        {
            if (emailRegex.IsMatch(request.UserNameOrEmail))
                return BadRequest<SignInResponse>("Email or Password are wrong");

            return BadRequest<SignInResponse>("User Name or Password are wrong");
        }

        //Ensure email is confirmed before allowing login
        if (!user.EmailConfirmed) return BadRequest<SignInResponse>("Please confirm your email before signing in.");

        //Check if user is locked out
        var lockoutMessage = await service.CheckAndHandleLockoutAsync(user);
        if (!string.IsNullOrEmpty(lockoutMessage))
        {
            return BadRequest<SignInResponse>(lockoutMessage);
        }
        var signInResult = await service.CheckPasswordAsync(user, request.Password);
        // Validate password
        if (!signInResult == true)
        {
            //await service.HandleFailedLoginAsync(user);
            return BadRequest<SignInResponse>("Invalid username or password.");
        }
        //Successful login
        await service.ResetFailedAttemptsAsync(user);
        var tokens = await service.GetJWTtoken(user);
        return Success(new SignInResponse
        {
            UserName = user.UserName,
            IsAuthenticated = true,
            Tokens = tokens
        });
    }
}