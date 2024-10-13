namespace MovieTicketApi.LoggerFactory
{
    public interface ICustomLogger
    {
        void InfoLog(string message); 
        void ErrorLog(string message);
    }
}
