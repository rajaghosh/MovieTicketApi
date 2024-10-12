using System.Net;

namespace MovieTicketApi.DTO
{
    public class TokenModel
    {
        public string Token_Id { get; set; }
        public string Token_Secret { get; set; }
        public string UserEmail { get; set; }
    }

    public class TokenDto
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Token { get; set; }
    }
}
