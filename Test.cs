using MovieTicketApi.DatabaseContext;
using MovieTicketApi.Entities;

namespace MovieTicketApi
{
    public class Test
    {
        public static void TestDB()
        {
            var context = new MovieTicketDbContext();
            context.Database.EnsureDeleted(); //This will drop the Db and then create it in the next step
            context.Database.EnsureCreated(); //Ensure if there is no new DB it will create one.


            List<MovieMaster> movies = new List<MovieMaster>()
            {
                new MovieMaster{ Name="Godzilla", Description="Action Movie", Language="Hindi", RunningMin=120},
                new MovieMaster{ Name="Stree2", Description="Horror Movie", Language="Hindi", RunningMin=120},
                new MovieMaster{ Name="Joker", Description="Action Movie", Language="Hindi", RunningMin=120}
            };
            context.MovieMasters.AddRange(movies);

            List<TheatreMaster> theatres = new List<TheatreMaster>()
            {
                new TheatreMaster{ Name="Inox-Kolkata", Description="Multiplex", Location="Kolkata"},
                new TheatreMaster{ Name="PVR-Kolkata", Description="Multiplex", Location="Kolkata"},
                new TheatreMaster{ Name="Inox-NCR", Description="Multiplex", Location="NCR"},
                new TheatreMaster{ Name="PVR-NCR", Description="Multiplex", Location="NCR"}
            };
            context.TheatreMasters.AddRange(theatres);

            context.SaveChanges();
        }
    }
}
