using Microsoft.Extensions.DependencyInjection;
using MovieTicketApi.Models;

namespace MovieTicketApi.LoggerFactory
{
    //public class LoggerFactory
    //{
    //    public static ILogger CreateLogger(LoggerType type)
    //    {
    //        ILogger logger;
    //        switch (type)
    //        {
    //            case LoggerType.ConsoleLog:
    //                logger = new ConsoleLogger();
    //                break;
    //            case LoggerType.FileLog:
    //                logger = new FileLogger();
    //                break;
    //            case LoggerType.DbLog:
    //                logger = new DbLogger();
    //                break;
    //            default:
    //                logger = new ConsoleLogger();
    //                break;
    //        }

    //        return logger;
    //    }
    //}

    //public interface ILoggerFactoryCore
    //{
    //    ILogger CreateLogger(LoggerType type);
    //}

    public class CustomLoggerFactory : ICustomLoggerFactory
    {
        private readonly IConfiguration _config;
        public CustomLoggerFactory(IConfiguration config) { _config = config; }

        public ILoggerObjContract CreateLogger(LoggerType type)
        {
            ILoggerObjContract logger;
            switch (type)
            {
                case LoggerType.ConsoleLog:
                    logger = new ConsoleLoggerFactory();
                    break;
                case LoggerType.FileLog:
                    logger = new FileLoggerFactory(_config);
                    break;
                case LoggerType.DbLog:
                    logger = new DbLoggerFactory();
                    break;
                default:
                    logger = new ConsoleLoggerFactory();
                    break;
            }

            return logger;
        }

        //public void LogWriter(string result, ICustomLogger logger)
        //{
        //    logger.Log(result);
        //}

    }

    public static class LogHelper
    {
        public static void Info_Log(this ILoggerObjContract logger, string result)
        {
            logger.InformationLog(result);
        }
        public static void Error_Log(this ILoggerObjContract logger, string result)
        {
            logger.ErrorLog(result);
        }
    }
}
