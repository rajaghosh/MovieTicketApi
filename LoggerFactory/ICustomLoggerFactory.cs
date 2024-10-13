using MovieTicketApi.Models;

namespace MovieTicketApi.LoggerFactory
{
    public interface ICustomLoggerFactory
    {
        ILoggerObjContract CreateLogger(LoggerType type);
    }
}
