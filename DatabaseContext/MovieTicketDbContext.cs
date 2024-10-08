using Microsoft.EntityFrameworkCore;
using MovieTicketApi.Entities;

namespace MovieTicketApi.DatabaseContext
{
    public class MovieTicketDbContext : DbContext //, IMovieTicketDbContext
    {
        public DbSet<MovieMaster> MovieMasters { get; set; }
        public DbSet<TheatreMaster> TheatreMasters { get; set; }
        public DbSet<UserMaster> UserMasters { get; set; }
        public DbSet<TheatreScreen> TheatreScreens { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public MovieTicketDbContext() { }
        public MovieTicketDbContext(DbContextOptions<MovieTicketDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=RAJA-LENOVO\\SQLEXPRESS;Initial Catalog=MovieTicket_3; Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
