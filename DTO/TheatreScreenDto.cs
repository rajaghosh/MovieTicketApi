namespace MovieTicketApi.DTO
{
    public class TheatreScreenDto
    {
        public string TheatreName { get; set; }
        public string ScreenName { get; set; }
        public required List<int> Rows { get; set; }
        public required List<string> SeatNos { get; set; }
    }

    public class TheatreScreenTotalDto : TheatreScreenDto
    {
        public int Id { get; set; }
    }

    public class AddTheatreScreenDto
    {
        public int TheatreId { get; set; }
        public required string ScreenName { get; set; }
        public required List<int> Rows { get; set; }
        public required List<string> SeatNos { get; set; }
    }

    public class UpdateTheatreScreenDto : AddTheatreScreenDto
    {
        public int Id { get; set; }
    }
}
