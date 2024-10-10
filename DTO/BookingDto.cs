using MovieTicketApi.Helper;

namespace MovieTicketApi.DTO
{
    public class BookingDto
    {
        [UserRole]
        public required string DoneBy { get; set; }
        public string? UserEmail { get; set; }
        public string MovieName { get; set; }
        public string TheatreName { get; set; }
        public string ScreenName { get; set; }
        public int Row { get; set; }
        public string SeatNo { get; set; }
        public string ShowTime { get; set; }
    }

    public class AddBookingDto
    {
        [UserRole]
        public required string DoneBy { get; set; }
        public int? UserId { get; set; }
        public int MovieId { get; set; }
        public int ScreenId { get; set; }
        public int Row { get; set; }
        public string SeatNo { get; set; }
        public DateTime BookingDateTime { get; set; }
    }

    public class UpdateBookingDto : AddBookingDto
    {
        public int Id { get; set; }
    }
}



