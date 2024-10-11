using Microsoft.AspNetCore.Mvc;
using MovieTicketApi.Services.Interface;

namespace MovieTicketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        //private readonly 
        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService; 

        }

        [HttpPost("GetToken")]
        public async Task<string> GetToken(string email, string password)
        {
            var userRole = await _userService.IsEmailValidAsync(email, password);
            var token = String.Empty;
            if(userRole.Length > 0)
            {
                token = await _authService.GenerateJwtToken(email, userRole);
            }
            return token;
        }

        //[HttpPost("ValidateToken")]
        //public async Task<string> CheckToken(string email, string password)
        //{
        //    var isUserValid = await _userService.IsEmailValidAsync(email, password);
        //    var token = String.Empty;
        //    if (isUserValid)
        //    {
        //        token = await _authService.GenerateJwtToken(email);
        //    }
        //    return token;
        //}
    }
}
