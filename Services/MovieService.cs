using MovieTicketApi.DBContext;
using MovieTicketApi.DBContext.Repo;
using MovieTicketApi.Models;

namespace MovieTicketApi.Services
{
    public class MovieService
    {
        private readonly MovieNameRepo _repo;

        public MovieService(MovieNameRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<MovieNameModel>> GetAllMovieNameAsync()
        {
            return await _repo.GetAllAsync();
        }
    }
}
