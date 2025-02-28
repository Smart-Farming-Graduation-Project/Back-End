using System.Security.Claims;

namespace Croppilot.API.Extensions
{
    public static class UserExtensions
    {
        public static string? GetUserId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue("Id");
        }
    }
}