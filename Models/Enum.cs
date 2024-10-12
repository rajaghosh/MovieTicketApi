namespace MovieTicketApi.Models
{
    public enum Roles
    {
        Admin,  //For theatre
        User,   //For customer
        All     //For Any Role
    }

    public enum LoggerType
    {
        ConsoleLog,
        DbLog,
        FileLog,
        AppInsightsLog
    }
}
