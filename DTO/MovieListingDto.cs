using MovieTicketApi.Helper;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTicketApi.DTO
{
    public class MovieListingDto
    {
        public string MovieName { get; set; }
        public string TheatreName { get; set; }
        public string ScreenName { get; set; }
        public string StartDate_StartTime { get; set; }
        public string EndDate_EndTime { get; set; }
        public string MovieRunningStatus { get; set; }
    }

    public class AddMovieListingDto
    {
        public int MovieId { get; set; }
        public int ScreenId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartTime { get; set; }
    }

    public class UpdateMovieListingDto : AddMovieListingDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }

    //movieId, theatreId, screenid, Date, Time
    public class ListingSearch
    {
        public int MovieId { get; set; }
        public int ScreenId { get; set; }
        public DateTime MovieStartDateTime { get; set; }
    }
}


