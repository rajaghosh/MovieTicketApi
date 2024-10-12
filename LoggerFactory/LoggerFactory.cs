namespace MovieTicketApi.LoggerFactory
{
    public class ConsoleLogger : ILoggerFactory
    {
        void ILoggerFactory.Log(string resp)
        {
            throw new NotImplementedException();
        }
    }
    public class FileLogger : ILoggerFactory
    {
        void ILoggerFactory.Log(string resp)
        {
            throw new NotImplementedException();
        }
    }
    public class DbLogger : ILoggerFactory
    {
        void ILoggerFactory.Log(string resp)
        {
            throw new NotImplementedException();
        }
    }
    public class AppInsightsLogger : ILoggerFactory
    {
        void ILoggerFactory.Log(string resp)
        {
            throw new NotImplementedException();
        }
    }
}
