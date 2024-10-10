using MovieTicketApi.DTO;
using MovieTicketApi.Entities;

namespace MovieTicketApi.Services.Interface
{
    public interface IMovieService
    {
        Task<List<MovieDto>> GetAllMovieNameAsync();
        Task<List<MovieMaster>> GetSpecificMovieDetailsAsync(List<int> movieIds);
        Task<bool> AddToMovieAsync(AddMovieDto movieDto);
        Task<bool> UpdateMovieAsync(UpdateMovieDto movieDto);
        Task<bool> DeleteMovieAsync(int movieId);
    }
}
