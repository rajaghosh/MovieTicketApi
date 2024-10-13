using Microsoft.AspNetCore.Mvc;
using MovieTicket.BusinessService.Services.Interface;
using MovieTicket.ModelHelper.DTO;
using MovieTicketApi.Helper;
using System.Net;

namespace MovieTicketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizeRole("All")]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("GetAllBookings")]
        public async Task<List<BookingDto>> GetAll()
        {
            var bookings = await _bookingService.GetAllBookingNameAsync();
            return bookings;
        }

        [HttpPost("AddNewBooking")]
        public async Task<HttpStatusCode> PostMovie([FromBody] AddBookingDto bookingDto)
        {
            var res = await _bookingService.AddToBookingAsync(bookingDto);
            return res == true ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
        }

        [HttpPut("UpdateBooking")]
        public async Task<HttpStatusCode> PutMovie(UpdateBookingDto bookingDto)
        {
            var res = await _bookingService.UpdateBookingAsync(bookingDto);
            return res == true ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
        }

        [HttpDelete("DeleteBooking")]
        public async Task<HttpStatusCode> Delete(int bookingId)
        {
            var res = await _bookingService.DeleteBookingAsync(bookingId);
            return res == true ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
        }
    }
}
