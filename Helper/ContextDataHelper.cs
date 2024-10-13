using System.Security.Claims;

namespace MovieTicketApi.Helper
{
    //This will be used to get the userId and role from the HttpContext 
    public static class ContextDataHelper
    {
        public static string UserDetails(this HttpContext context)
        {
            var userContext = context.User;
            var userId = userContext.FindFirst("user")?.Value;
            var userRole = userContext.FindFirst(ClaimTypes.Role)?.Value;

            return $"{userId} / {userRole}";
        }
    }
}
