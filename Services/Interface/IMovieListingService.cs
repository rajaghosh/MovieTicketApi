using MovieTicketApi.DTO;
using MovieTicketApi.Entities;

namespace MovieTicketApi.Services.Interface
{
    public interface IMovieListingService
    {
        Task<List<MovieListingDto>> GetAllMovieListingAsync();
        Task<MovieListing> GetSpecificMovieListingDetailsAsync(ListingSearch listingDto);
        Task<bool> AddToMovieListingAsync(AddMovieListingDto movieListingDto);
        Task<bool> UpdateMovieListingAsync(UpdateMovieListingDto movieListingDto);
        Task<bool> DeleteMovieListingAsync(int movieListingId);
    }
}
