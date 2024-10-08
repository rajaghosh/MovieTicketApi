using MovieTicketApi.DBContext;
using MovieTicketApi.Models;

namespace MovieTicketApi.DBContext.Repo
{
    public class MovieNameRepo : DbRepository<MovieNameModel>
    {
        public MovieNameRepo(MTContext dbContext) : base(dbContext)
        {

        }
    }
}

