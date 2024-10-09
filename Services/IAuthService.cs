using Microsoft.Extensions.Hosting;
using MovieTicketApi.DTO;

namespace MovieTicketApi.Services
{
    public interface IAuthService 
    {
        Task<string> GenerateJwtToken(string email);
        Task<bool> ValidateJwtToken(string token);
    }
}
