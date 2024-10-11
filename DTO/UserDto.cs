using MovieTicketApi.Helper;

namespace MovieTicketApi.DTO
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Location { get; set; }
        public string TypeOfUser { get; set; }
    }

    public class AddUserDto
    {
        public string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        [UserRole]
        public required string TypeOfUser { get; set; }
        public string? Location { get; set; }
    }

    public class UpdateUserDto : AddUserDto
    {
        public int Id { get; set; }
    }
}
