using Microsoft.AspNetCore.Mvc.Filters;
using MovieTicket.ModelHelper.Models;

namespace MovieTicketApi.Helper
{
    public class AuthorizeRoleAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] _roles;

        public AuthorizeRoleAttribute(params string[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new Microsoft.AspNetCore.Mvc.UnauthorizedResult();
                return;
            }
           
            if(_roles.Contains(Roles.All.ToString()))      //Check for general role
            {
                return;
            }
            else if (_roles.Any(role => user.IsInRole(role)))    //Check for specific role 
            {
                return;
            }

            context.Result = new Microsoft.AspNetCore.Mvc.ForbidResult();
        }
    }
}
    