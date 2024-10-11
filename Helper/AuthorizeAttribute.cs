using Microsoft.AspNetCore.Mvc.Filters;
using MovieTicketApi.Models;

namespace MovieTicketApi.Helper
{
    //[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    //public class Authorization : Attribute, IAuthorizationFilter
    //{
    //    private readonly IList<Roles> _roles;
    //    public Authorization(params Roles[] _roles)
    //    {
    //        this._roles = _roles ?? new Roles[] { };
    //    }

    //    public void OnAuthorization(AuthorizationFilterContext context)
    //    {
    //        //var isRolePermission = false;
    //        //User user = (User)context.HttpContext.Items["User"];
    //        //if (user == null)
    //        //{
    //        //    context.Result = new JsonResult(
    //        //            new { Message = "Unauthorization" }
    //        //        )
    //        //    { StatusCode = StatusCodes.Status401Unauthorized };
    //        //}
    //        //if (user != null && this._roles.Any())
    //        //    foreach (var userRole in user.Role)
    //        //    {
    //        //        foreach (var AuthRole in this._roles)
    //        //        {

    //        //            if (userRole == AuthRole)
    //        //            {
    //        //                isRolePermission = true;
    //        //            }
    //        //        }
    //        //    }

    //        //if (!isRolePermission)
    //        //    context.Result = new JsonResult(
    //        //               new { Message = "Unauthorization" }
    //        //           )
    //        //    { StatusCode = StatusCodes.Status401Unauthorized };

    //        var authorization = context.HttpContext.Items["Authorization"];
    //        //var tokenString = authorization[0]?.Replace("Bearer ", "").Replace("bearer ", "").Trim();

    //        ////var userUnlockKey = context.Request.Headers["UserKey"][0];

    //        //var token = _jwtService.ValidateJwtToken(tokenString).GetAwaiter().GetResult();

    //        //if (token)
    //        //{
    //        //    context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
    //        //    //await _next(context);
    //        //}
    //        //else
    //        //{
    //        //    context.Response.Clear();
    //        //    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
    //        //    await context.Response.WriteAsync("Unauthorizzed");
    //        //}
    //    }
    //}
}
