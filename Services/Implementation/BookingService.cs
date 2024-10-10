using MovieTicketApi.DatabaseContext.Repo;
using MovieTicketApi.DTO;
using MovieTicketApi.Entities;
using MovieTicketApi.Services.Interface;

namespace MovieTicketApi.Services.Implementation
{
    public class BookingService : IBookingService
    {
        private readonly IMovieTicketRepository<Booking> _repo;
        private readonly ITheatreScreenService _screenService;
        private readonly IMovieService _movieService;
        private readonly IUserService _userService;

        public BookingService(IMovieTicketRepository<Booking> repo,
                                ITheatreScreenService screenService,
                                IMovieService movieService,
                                IUserService userService)
        {
            _repo = repo;
            _screenService = screenService;
            _movieService = movieService;
            _userService = userService;
        }



        public async Task<List<BookingDto>> GetAllBookingNameAsync()
        {
            try
            {
                var bookings = await _repo.GetAllAsync();

                var userIds = bookings.Select(x => x.UserId ?? 0).ToList();
                var movieIds = bookings.Select(p => p.MovieId).ToList();
                var screenIds = bookings.Select(p => p.ScreenId).ToList();

                Task<List<UserMaster>> userDetailsTask = _userService.GetSpecificUserDetailsAsync(userIds);
                Task<List<MovieMaster>> movieDetailsTask = _movieService.GetSpecificMovieDetailsAsync(movieIds);
                Task<List<TheatreScreenTotalDto>> screenDetailsTask = _screenService.GetSpecificTheatreScreenDetailsAsync(screenIds);

                await Task.WhenAll(userDetailsTask, movieDetailsTask, screenDetailsTask);

                List<UserMaster> userDetails = userDetailsTask.Result;
                List<MovieMaster> movieDetails = movieDetailsTask.Result;
                List<TheatreScreenTotalDto> screenDetails = screenDetailsTask.Result;

                List<BookingDto> result = new List<BookingDto>();
                foreach (var item in bookings)
                {
                    BookingDto bookingObj = new BookingDto()
                    {
                        DoneBy = item.DoneBy,
                        UserEmail = userDetails.Where(p => p.Id == item.UserId).FirstOrDefault()?.Email ?? "",
                        MovieName = movieDetails.Where(p => p.Id == item.MovieId).FirstOrDefault()?.Name ?? "",
                        TheatreName = screenDetails.Where(p => p.Id == item.MovieId).FirstOrDefault()?.TheatreName ?? "",
                        ScreenName = screenDetails.Where(p => p.Id == item.ScreenId).FirstOrDefault()?.ScreenName ?? "",
                        Row = item.Row,
                        SeatNo = item.SeatNo,
                        ShowTime = item.ShowTime.ToString("hh:mm:ss tt") // 12-hour format with AM/PM
                    };
                    result.Add(bookingObj);
                }
                return result;
            }
            catch (Exception ex)
            {
                return new List<BookingDto>();
            }
        }

        public async Task<bool> AddToBookingAsync(AddBookingDto bookingDto)
        {
            try
            {
                var bookingTime = $"{bookingDto.BookingHour.ToString("D2")}:{bookingDto.BookingMin.ToString("D2")}:00"; //ToString("D2") - this will make sure format is HH:mm:ss

                //Check if the seat is already book
                var checkBookingAll = await _repo.GetAllAsync();
                var checkBookingId = checkBookingAll.ToList()
                                        .Where(p => p.Row == bookingDto.Row &&
                                                p.SeatNo == bookingDto.SeatNo &&
                                                p.ShowTime.ToString("HH:mm:ss").Equals(bookingTime)).FirstOrDefault()?.Id ?? 0;

                if (checkBookingId != 0)
                {
                    throw new Exception("The seat is already booked");
                }

                var bookingObj = new Booking()
                {
                    DoneBy = bookingDto.DoneBy,
                    UserId = bookingDto.UserId,
                    MovieId = bookingDto.MovieId,
                    ScreenId = bookingDto.ScreenId,
                    Row = bookingDto.Row,
                    SeatNo = bookingDto.SeatNo,
                    ShowTime = DateTime.ParseExact(bookingTime, "HH:mm:ss", null)
                };

                await _repo.AddAsync(bookingObj);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateBookingAsync(UpdateBookingDto bookingDto)
        {
            try
            {
                var bookingTime = $"{bookingDto.BookingHour.ToString("D2")}:{bookingDto.BookingMin.ToString("D2")}:00"; //ToString("D2") - this will make sure format is HH:mm:ss

                var bookingObj = new Booking()
                {
                    Id = bookingDto.Id,
                    DoneBy = bookingDto.DoneBy,
                    UserId = bookingDto.UserId,
                    MovieId = bookingDto.MovieId,
                    ScreenId = bookingDto.ScreenId,
                    Row = bookingDto.Row,
                    SeatNo = bookingDto.SeatNo,
                    ShowTime = DateTime.ParseExact(bookingTime, "HH:mm:ss", null)
                };

                await _repo.UpdateAsync(bookingObj);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteBookingAsync(int bookingId)
        {
            try
            {
                var da = await _repo.GetByIdAsync(bookingId);
                if (da == null)
                    return false;
                else
                {
                    await _repo.DeleteAsync(da);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }


    }
}
