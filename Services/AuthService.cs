using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;
using MovieTicketApi.DatabaseContext.Repo;
using MovieTicketApi.DTO;
using MovieTicketApi.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MovieTicketApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMovieTicketRepository<UserMaster> _repo;
        private readonly IConfiguration _config;
        private readonly byte[] key;
        private readonly string _jwt_key;
        private readonly string _jwt_id;
        private readonly string _jwt_secret;
        private readonly string _jwt_audience;
        private readonly string _jwt_issuer;

        public AuthService(IMovieTicketRepository<UserMaster> repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
            _jwt_key = _config.GetValue<string>("Jwt:jwt_key") ?? "";
            _jwt_id = _config.GetValue<string>("Jwt:jwt_id") ?? "";
            _jwt_secret = _config.GetValue<string>("Jwt:jwt_secret") ?? "";
            _jwt_audience = _config.GetValue<string>("Jwt:jwt_audience") ?? "";
            _jwt_issuer = _config.GetValue<string>("Jwt:jwt_issuer") ?? "";

        }

        public async Task<string> GenerateJwtToken(string email)
        {
            TokenModel model = new TokenModel()
            {
                Token_Id = _jwt_id,
                Token_Secret = _jwt_secret,
                UserEmail = email
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                List<Claim> claimList = new List<Claim>();
                claimList.Add(new Claim("id", model.Token_Id.ToString()));
                claimList.Add(new Claim("secret", model.Token_Secret.ToString()));
                claimList.Add(new Claim("user", model.UserEmail.ToString()));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claimList),
                    Audience = _jwt_audience,
                    Issuer = _jwt_issuer,
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                SecurityToken token = await Task.Run(() =>
                {
                    return tokenHandler.CreateToken(tokenDescriptor);
                });

                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> ValidateJwtToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _jwt_issuer,
                    ValidAudience = _jwt_audience,

                    ClockSkew = TimeSpan.Zero //token expires exactly at token expiration time

                }, out SecurityToken validatedToken);

                Task.WaitAll();

                var jwtToken = (JwtSecurityToken)validatedToken;
                var id = jwtToken.Claims.First(x => x.Type == "id").Value;
                var secret = jwtToken.Claims.First(x => x.Type == "secret").Value;

                var jwtId = _jwt_id;
                var jwtSecret = _jwt_secret;

                if (id == jwtId && secret == jwtSecret)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }

        }

    }
}
