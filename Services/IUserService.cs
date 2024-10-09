namespace MovieTicketApi.Services
{
    public interface IUserService
    {
        Task<bool> IsEmailValidAsync(string email, string password);
    }
}
