using HotelBooking.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepositories _blogRepositories ;

        public BlogController(IBlogRepositories blogRepositories)
        {
            _blogRepositories = blogRepositories;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
