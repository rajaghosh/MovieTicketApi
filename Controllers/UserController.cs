using Microsoft.AspNetCore.Mvc;
using MovieTicket.BusinessService.Services.Interface;
using MovieTicket.ModelHelper.DTO;
using MovieTicketApi.Helper;
using System.Net;

namespace MovieTicketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizeRole("All")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUser")]
        public async Task<List<UserDto>> GetAll()
        {
            var users = await _userService.GetAllUserNameAsync();
            return users;
        }

        [HttpPost("AddNewUser")]
        public async Task<HttpStatusCode> PostMovie(AddUserDto userDto)
        {
            var res = await _userService.AddToUserAsync(userDto);
            return res == true ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
        }

        [HttpPut("UpdateUser")]
        public async Task<HttpStatusCode> PutMovie(UpdateUserDto userDto)
        {
            var res = await _userService.UpdateUserAsync(userDto);
            return res == true ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
        }

        [HttpDelete("DeleteUser")]
        public async Task<HttpStatusCode> Delete(int userId)
        {
            var res = await _userService.DeleteUserAsync(userId);
            return res == true ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
        }
    }
}
