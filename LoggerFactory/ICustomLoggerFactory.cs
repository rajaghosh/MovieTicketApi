using MovieTicket.ModelHelper.Models;

namespace MovieTicketApi.LoggerFactory
{
    public interface ICustomLoggerFactory
    {
        ILoggerObjContract CreateLogger(LoggerType type);
    }
}
