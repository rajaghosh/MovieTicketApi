using MovieTicketApi.DTO;
using MovieTicketApi.Entities;

namespace TheatreTicketApi.Services.Interface
{
    public interface ITheatreService
    {
        Task<List<TheatreDto>> GetAllTheatreNameAsync();
        Task<List<TheatreMaster>> GetSpecificTheatreDetailsAsync(List<int> theatreIds);
        Task<bool> AddToTheatreAsync(AddTheatreDto theatreDto);
        Task<bool> UpdateTheatreAsync(UpdateTheatreDto theatreDto);
        Task<bool> DeleteTheatreAsync(int theatreId);
    }
}
