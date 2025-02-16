using Croppilot.Core.Features.Authentication.Commands.Models;
using Croppilot.Core.Features.Authentication.Commands.Result;
using Croppilot.Date.Identity;
using System.ComponentModel.DataAnnotations;

namespace Croppilot.Core.Features.Authentication.Commands.Handlers;

public class SignInCommandHandler(
    IAuthenticationService service,
    IUserService userService)
    : ResponseHandler, IRequestHandler<SignInCommand, Response<SignInResponse>>
{
    public async Task<Response<SignInResponse>> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        ApplicationUser user;
        if (new EmailAddressAttribute().IsValid(request.UserNameOrEmail))
            user = await userService.GetUserByEmail(request.UserNameOrEmail);
        else
            user = await userService.GetUserByUserName(request.UserNameOrEmail);

        if (user is null)
        {
            var errors = new List<Error>
            {
                new Error
                {
                    Code = "InvalidCredentials",
                    Message = "Username or Password are wrong",
                    Field = "UserNameOrEmail"
                }
            };
            return BadRequest<SignInResponse>(errors, "Authentication error");
        }

        if (!user.EmailConfirmed)
        {
            var errors = new List<Error>
            {
                new Error
                {
                    Code = "EmailNotConfirmed",
                    Message = "Please confirm your email before signing in.",
                    Field = "Email"
                }
            };
            return BadRequest<SignInResponse>(errors, "Authentication error");
        }

        var lockoutMessage = await service.CheckAndHandleLockoutAsync(user);
        if (!string.IsNullOrEmpty(lockoutMessage))
        {
            var errors = new List<Error>
            {
                new Error
                {
                    Code = "AccountLocked",
                    Message = lockoutMessage,
                    Field = "UserNameOrEmail"
                }
            };
            return BadRequest<SignInResponse>(errors, "Authentication error");
        }

        var signInResult = await service.CheckPasswordAsync(user, request.Password);
        if (!signInResult)
        {
            var errors = new List<Error>
            {
                new Error
                {
                    Code = "InvalidCredentials",
                    Message = "Invalid username or password.",
                    Field = "Password"
                }
            };
            return BadRequest<SignInResponse>(errors, "Authentication error");
        }

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