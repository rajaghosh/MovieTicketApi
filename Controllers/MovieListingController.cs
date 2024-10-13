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
    public class MovieListingController : Controller
    {
        private readonly IMovieListingService _movieListingService;
        public MovieListingController(IMovieListingService movieListingService)
        {
            _movieListingService = movieListingService;
        }

        [HttpGet("GetAllMovieListing")]
        public async Task<List<MovieListingDto>> GetAll()
        {
            var movieListings = await _movieListingService.GetAllMovieListingAsync();
            return movieListings;
        }

        [HttpPost("AddNewMovieListing")]
        public async Task<HttpStatusCode> PostMovie(AddMovieListingDto bookingDto)
        {
            var res = await _movieListingService.AddToMovieListingAsync(bookingDto);
            return res == true ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
        }

        [HttpPut("UpdateMovieListing")]
        public async Task<HttpStatusCode> PutMovie(UpdateMovieListingDto bookingDto)
        {
            var res = await _movieListingService.UpdateMovieListingAsync(bookingDto);
            return res == true ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
        }

        [HttpDelete("DeleteMovieListing")]
        public async Task<HttpStatusCode> Delete(int movieListingId)
        {
            var res = await _movieListingService.DeleteMovieListingAsync(movieListingId);
            return res == true ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
        }
    }
}
