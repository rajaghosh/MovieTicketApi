using Microsoft.Extensions.Hosting;
using MovieTicketApi.DTO;

namespace MovieTicketApi.Services
{
    public interface IMovieService 
    {
        Task<List<MovieDto>> GetAllMovieNameAsync();
        Task<bool> AddToMovieAsync(AddMovieDto movieDto);
        Task<bool> UpdateMovieAsync(UpdateMovieDto movieDto);
        Task<bool> DeleteMovieAsync(int movieId);
    }
}
