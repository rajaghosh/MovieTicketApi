using MovieTicket.BusinessService.Services.Interface;
using System.Net;

namespace MovieTicketApi.Middleware
{
    public class RequestHeaderMiddleware
    {
        private readonly RequestDelegate _next;
 
        public RequestHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IAuthService _jwtService)
        {
            var requestPath = context.Request.Path.Value.ToLower();
            if (requestPath.Contains("/api/auth/gettoken"))
            {
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                await _next(context);
            }
            else
            {
                var authorization = context.Request.Headers["Authorization"];
                var tokenString = authorization[0]?.Replace("Bearer ", "").Replace("bearer ", "").Trim();

                //var userUnlockKey = context.Request.Headers["UserKey"][0];

                var token = _jwtService.ValidateJwtToken(tokenString).GetAwaiter().GetResult();

                if (token)
                {
                    context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                    await _next(context);
                }
                else
                {
                    context.Response.Clear();
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    await context.Response.WriteAsync("Unauthorizzed");
                }

            }
        }

    }
}
