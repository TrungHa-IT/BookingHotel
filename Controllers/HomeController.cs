using HotelBooking.Models;
using HotelBooking.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HotelBooking.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceCategoriesRepositories _serviceCategoriesRepositories;
        private readonly IServiceRepositories _serviceRepositories;

        public HomeController(IServiceCategoriesRepositories serviceCategoriesRepositories, IServiceRepositories serviceRepositories)
        {
            _serviceCategoriesRepositories = serviceCategoriesRepositories;
            _serviceRepositories = serviceRepositories;
        }

        public async Task<IActionResult> Index()
        {
            var sc = await _serviceCategoriesRepositories.GetAllServiceCategoriesAsync();
            return View(sc);
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult blogdetail()
        {
            return View();
        }

        public IActionResult rooms()
        {
            return View();
        }

        public async Task<IActionResult> cservicedetail(int id)
        {
            var sc = await _serviceRepositories.GetServiceByIdServiceCategoryAsync(id);
            return View(sc);
        }

        public async Task<IActionResult> servicedetail(int id)
        {
             var service = await _serviceRepositories.GetServiceByIdAsync(id);
            return View(service);
        }


        public IActionResult roomdetails()
        {
            return View();
        }

            public IActionResult main()
            {
                return View();
            }

        public IActionResult about()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
