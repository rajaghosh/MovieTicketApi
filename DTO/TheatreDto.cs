namespace MovieTicketApi.DTO
{
    public class TheatreDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
    }

    public class AddTheatreDto
    {
        public required string Name { get; set; }
        public required string Location { get; set; }
        public string? Description { get; set; }
    }

    public class UpdateTheatreDto : AddTheatreDto
    {
        public int Id { get; set; }
    }
}
