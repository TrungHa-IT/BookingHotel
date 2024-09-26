using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers
{
    public class DashboradController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
