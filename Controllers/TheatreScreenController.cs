using Microsoft.AspNetCore.Mvc;
using MovieTicketApi.DTO;
using MovieTicketApi.Helper;
using MovieTicketApi.Services.Interface;
using System.Net;

namespace MovieTicketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizeRole("All")]
    public class TheatreScreenController : Controller
    {
        private readonly ITheatreScreenService _theatreScreenService;
        public TheatreScreenController(ITheatreScreenService theatreScreenService)
        {
            _theatreScreenService = theatreScreenService;
        }

        [HttpGet("GetAllTheatreScreen")]
        public async Task<List<TheatreScreenDto>> GetAll()
        {
            var theatreScreens = await _theatreScreenService.GetAllTheatreScreenAsync();
            return theatreScreens;
        }

        [HttpPost("AddNewTheatreScreen")]
        public async Task<HttpStatusCode> PostMovie(AddTheatreScreenDto theatreScreenDto)
        {
            var res = await _theatreScreenService.AddToTheatreScreenAsync(theatreScreenDto);
            return res == true ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
        }

        [HttpPut("UpdateTheatreScreen")]
        public async Task<HttpStatusCode> PutMovie(UpdateTheatreScreenDto theatreScreenDto)
        {
            var res = await _theatreScreenService.UpdateTheatreScreenAsync(theatreScreenDto);
            return res == true ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
        }

        [HttpDelete("DeleteTheatreScreen")]
        public async Task<HttpStatusCode> Delete(int theatreScreenId)
        {
            var res = await _theatreScreenService.DeleteTheatreScreenAsync(theatreScreenId);
            return res == true ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
        }
    }
}
