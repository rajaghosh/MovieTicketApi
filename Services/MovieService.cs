using MovieTicketApi.DTO;
using MovieTicketApi.Entities;
using MovieTicketApi.Models;
using MovieTicketApi.Repo;

namespace MovieTicketApi.Services
{
    public class MovieService: IMovieService
    {
        private readonly IMovieTicketRepository<MovieMaster> _repo;

        public MovieService(IMovieTicketRepository<MovieMaster> repo)
        {
            _repo = repo;
        }

        public async Task<List<MovieDto>> GetAllMovieNameAsync()
        {
            var movies = await _repo.GetAllAsync();
            List<MovieDto> result = new List<MovieDto>();
            foreach (var item in movies)
            {
                MovieDto movieObj = new MovieDto()
                {
                    Name = item.Name,
                    Language = item.Language,
                    RunTime = item.RunningMin
                };
                result.Add(movieObj);
            }
            return result;
        }
    }
}
