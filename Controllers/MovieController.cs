using Microsoft.AspNetCore.Mvc;
using MovieTicketApi.DatabaseContext;
using MovieTicketApi.DTO;
using MovieTicketApi.Entities;
using MovieTicketApi.Services;
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

        [HttpGet("GetMovie")]
        public List<MovieDto> Get()
        {
            var context = new MovieTicketDbContext();
            return context.MovieMasters.Select(p => new MovieDto()
            {
                Name = p.Name,
                Language = p.Language,
                RunTime = p.RunningMin
            }).ToList();
        }

        [HttpGet("GetAllMovie")]
        public async Task<List<MovieDto>> GetAll()
        {
            //var context = new MovieTicketDbContext();
            //return context.MovieMasters.Select(p => new MovieDto()
            //{
            //    Name = p.Name,
            //    Language = p.Language,
            //    RunTime = p.RunningMin
            //}).ToList();
            var movies = await _movieService.GetAllMovieNameAsync();
            return movies;
        }

        [HttpPost("AddMovie")]
        public HttpStatusCode Post(AddMovieDto movieDto)
        {
            var context = new MovieTicketDbContext();
            var movieObj = new MovieMaster()
            {
                Name = movieDto.Name,
                Language = movieDto.Language,
                Description = movieDto.Description,
                RunningMin = movieDto.RunTime
            };

            context.MovieMasters.Add(movieObj);

            context.SaveChanges();
            return HttpStatusCode.OK;
        }

        [HttpPut("UpdateMovie")]
        public HttpStatusCode Put(UpdateMovieDto movieDto)
        {
            var context = new MovieTicketDbContext();
            var movieObj = new MovieMaster()
            {
                Id = movieDto.Id,
                Name = movieDto.Name,
                Language = movieDto.Language,
                Description = movieDto.Description,
                RunningMin = movieDto.RunTime
            };

            context.MovieMasters.Update(movieObj);

            context.SaveChanges();
            return HttpStatusCode.OK;
        }

        [HttpDelete("DeleteMovie")]
        public HttpStatusCode Delete(int movieId)
        {
            var context = new MovieTicketDbContext();
            var movieObj = context.MovieMasters.First(x => x.Id == movieId);

            context.MovieMasters.Remove(movieObj);

            context.SaveChanges();
            return HttpStatusCode.OK;
        }

    }
}
