using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MovieTicketApi.Middleware
{
    public static class AuthenticationMiddleware
    {
        public static IServiceCollection GetToken(this IServiceCollection service, IConfiguration config)
        {
            var key = Encoding.ASCII.GetBytes(config.GetValue<string>("Jwt:jwt_key") ?? "");
            var _jwt_issuer = config.GetValue<string>("Jwt:jwt_issuer") ?? "";
            var _jwt_audience = config.GetValue<string>("Jwt:jwt_audience") ?? "";

            service.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = _jwt_issuer,
                        ValidAudience = _jwt_audience,
                    };
                });

            return service;

        }
    }
}
