using System.Net;

namespace MovieTicketApi.DTO
{
    public class ResponseDto<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public T? Result { get; set; }
        //public ErrorCode? Error { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
