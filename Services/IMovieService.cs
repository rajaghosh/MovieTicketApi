using MovieTicketApi.DTO;

namespace MovieTicketApi.Services
{
    public interface IMovieService 
    {
        Task<List<MovieDto>> GetAllMovieNameAsync();
    }
}
