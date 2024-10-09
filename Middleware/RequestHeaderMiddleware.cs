using MovieTicketApi.Services;
using System.Net;

namespace MovieTicketApi.Middleware
{
    public class RequestHeaderMiddleware
    {
        private readonly RequestDelegate _next;
        private IAuthService _jwtService;
        public RequestHeaderMiddleware(RequestDelegate next, IAuthService jwtService)
        {
            _next = next;
            _jwtService = jwtService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //var requestPath = context.Request.Path.Value.ToLower();

            //if (requestPath.Contains("/api/user/addnewuser")
            //    || requestPath.Contains("/api/user/loginuser")
            //    || requestPath.Contains("/api/user/getvalidationforaffliateuser")
            //    //|| requestPath.Contains("/api/user/checksanityofaffliateasync")
            //    //|| requestPath.Contains("/api/user/updatesaleaffliateasync")
            //    || requestPath.Contains("/api/product/syncaffliatepayments")
            //    || requestPath.Contains("/weatherforecast")
            //    || requestPath == "/")
            //{
            //    context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
            //    await _next(context);
            //}
            //else
            //{
            //context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
            await _next(context);

            var authorization = context.Request.Headers["Authorization"];
            var tokenString = authorization[0].Replace("Bearer ", "").Replace("bearer ", "").Trim();

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

            //}
        }

    }
}
