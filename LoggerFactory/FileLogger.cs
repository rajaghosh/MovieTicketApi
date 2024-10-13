using MovieTicket.ModelHelper.Models;

namespace MovieTicketApi.LoggerFactory
{
    public class FileLogger: ICustomLogger
    {
        private readonly ICustomLoggerFactory _loggerFactory;
        private readonly ILoggerObjContract _logger;

        public FileLogger(ICustomLoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger(LoggerType.FileLog);
        }

        public void InfoLog(string message)
        {
            _logger.Info_Log(message);
        }

        public void ErrorLog(string message)
        {
            _logger.Info_Log(message);
        }
    }
}
