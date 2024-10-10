using MovieTicketApi.DTO;

namespace MovieTicketApi.Services.Interface
{
    public interface IBookingService
    {
        Task<List<BookingDto>> GetAllBookingNameAsync();
        Task<bool> AddToBookingAsync(AddBookingDto bookingDto);
        Task<bool> UpdateBookingAsync(UpdateBookingDto bookingDto);
        Task<bool> DeleteBookingAsync(int bookingId);
    }
}
