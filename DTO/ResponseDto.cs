using System.Net;

namespace MovieTicketApi.DTO
{
    public class ResponseDto<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public T? Result { get; set; }
        public ErrorCode Error { get; set; }
    }

    public class ErrorModel
    {
        public ErrorCode ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public enum ErrorCode
    {
        NotFound = 404,
        InternalServerError = 500,
        ExternalApiError = 501,
        UnAuthorize = 401,
        PaymentFailed = 410
    }
}
