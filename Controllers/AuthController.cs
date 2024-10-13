using Microsoft.AspNetCore.Mvc;
using MovieTicket.BusinessService.Services.Interface;
using MovieTicket.ModelHelper.DTO;
using System.ComponentModel.DataAnnotations;

namespace MovieTicketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService; 

        }

        [HttpPost("GetToken")]
        public async Task<TokenDto> GetToken([FromQuery][Required] string email, [FromQuery][Required] string password)
        {
            TokenDto resp = new TokenDto
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Token = String.Empty
            };

            try
            {
                var userRole = await _userService.IsEmailValidAsync(email, password);
                
                string token = string.Empty;
                if (userRole.Length > 0)
                {
                    token = await _authService.GenerateJwtToken(email, userRole);
                }
                resp.StatusCode = System.Net.HttpStatusCode.OK;
                resp.Token = token;

                return resp;
            }
            catch (Exception ex)
            {
                return resp;
            }
        }
    }
}
