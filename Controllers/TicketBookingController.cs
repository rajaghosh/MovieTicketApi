using Microsoft.AspNetCore.Mvc;

namespace MovieTicketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketBookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
