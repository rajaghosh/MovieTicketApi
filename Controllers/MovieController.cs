using Microsoft.AspNetCore.Mvc;
using MovieTicketApi.DatabaseContext;
using MovieTicketApi.DTO;
using MovieTicketApi.Entities;
using System.Net;

namespace MovieTicketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
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
