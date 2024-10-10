using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieTicketApi.DatabaseContext;
using MovieTicketApi.DTO;
using MovieTicketApi.Entities;
using MovieTicketApi.Services.Interface;
using System.Net;

namespace MovieTicketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("GetAllMovie")]
        public async Task<List<MovieDto>> GetAll()
        {
            var movies = await _movieService.GetAllMovieNameAsync();
            return movies;
        }

        [Authorize]
        [HttpGet("GetAllMovieTest")]
        public async Task<List<MovieDto>> GetAll_Test()
        {
            var movies = await _movieService.GetAllMovieNameAsync();
            return movies;
        }


        [HttpPost("AddNewMovie")]
        public async Task<HttpStatusCode> PostMovie(AddMovieDto movieDto)
        {
            var res = await _movieService.AddToMovieAsync(movieDto);
            return res == true ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
        }

        [HttpPut("UpdateMovie")]
        public async Task<HttpStatusCode> PutMovie(UpdateMovieDto movieDto)
        {
            var res = await _movieService.UpdateMovieAsync(movieDto);
            return res == true ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
        }

        [HttpDelete("DeleteMovie")]
        public async Task<HttpStatusCode> Delete(int movieId)
        {
            var res = await _movieService.DeleteMovieAsync(movieId);
            return res == true ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
        }
    }
}


