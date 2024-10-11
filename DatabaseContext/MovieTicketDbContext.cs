using Microsoft.EntityFrameworkCore;
using MovieTicketApi.Entities;

namespace MovieTicketApi.DatabaseContext
{
    public class MovieTicketDbContext : DbContext
    {
        public DbSet<MovieMaster> MovieMasters { get; set; }
        public DbSet<TheatreMaster> TheatreMasters { get; set; }
        public DbSet<UserMaster> UserMasters { get; set; }
        public DbSet<TheatreScreen> TheatreScreens { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<MovieListing> MovieListings { get; set; }

        public MovieTicketDbContext() { }
        public MovieTicketDbContext(DbContextOptions<MovieTicketDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContextOptionsBuilder).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovieMaster>().HasData(
                new MovieMaster { Id = 1, Name = "Godzilla", Description = "Action Movie", Language = "Hindi", RunningMin = 120 },
                new MovieMaster { Id = 2, Name = "Stree2", Description = "Horror Movie", Language = "Hindi", RunningMin = 120 },
                new MovieMaster { Id = 3, Name = "Joker", Description = "Action Movie", Language = "Hindi", RunningMin = 120 }
            );

            modelBuilder.Entity<TheatreMaster>().HasData(
                new TheatreMaster { Id = 1, Name = "Inox-Kolkata", Description = "Multiplex", Location = "Kolkata" },
                new TheatreMaster { Id = 2, Name = "PVR-Kolkata", Description = "Multiplex", Location = "Kolkata" },
                new TheatreMaster { Id = 3, Name = "Inox-NCR", Description = "Multiplex", Location = "NCR" },
                new TheatreMaster { Id = 4, Name = "PVR-NCR", Description = "Multiplex", Location = "NCR" }
            );

            modelBuilder.Entity<UserMaster>().HasData(
                new UserMaster { Id = 1, Name = "a1", Email = "a1@deloitte.com", Password = "abc1@123", Location = "kolkata", Role = "Admin" },
                new UserMaster { Id = 2, Name = "a2", Email = "a2@deloitte.com", Password = "abc2@123", Location = "Hyderabad", Role = "Admin" },
                new UserMaster { Id = 3, Name = "a3", Email = "a3@deloitte.com", Password = "abc3@123", Location = "Pune",Role = "User" },
                new UserMaster { Id = 4, Name = "a4", Email = "a4@deloitte.com", Password = "abc4@123", Location = "NCR",Role = "User" }
            );
        }
    }
}
