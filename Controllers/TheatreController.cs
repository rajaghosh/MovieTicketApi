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
    public class TheatreController : Controller
    {
        private readonly ITheatreService _theatreService;
        public TheatreController(ITheatreService theatreService)
        {
            _theatreService = theatreService;
        }

        [HttpGet("GetAllTheatre")]
        public async Task<List<TheatreDto>> GetAll()
        {
            var theatres = await _theatreService.GetAllTheatreNameAsync();
            return theatres;
        }

        [HttpPost("AddNewTheatre")]
        public async Task<HttpStatusCode> PostMovie(AddTheatreDto theatreDto)
        {
            var res = await _theatreService.AddToTheatreAsync(theatreDto);
            return res == true ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
        }

        [HttpPut("UpdateTheatre")]
        public async Task<HttpStatusCode> PutMovie(UpdateTheatreDto theatreDto)
        {
            var res = await _theatreService.UpdateTheatreAsync(theatreDto);
            return res == true ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
        }

        [HttpDelete("DeleteTheatre")]
        public async Task<HttpStatusCode> Delete(int theatreId)
        {
            var res = await _theatreService.DeleteTheatreAsync(theatreId);
            return res == true ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
        }
    }
}
