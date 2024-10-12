namespace MovieTicketApi.Services.Interface
{
    public interface IAuthService
    {
        Task<string> GenerateJwtToken(string email, string userRole);
        Task<bool> ValidateJwtToken(string token);
    }
}
