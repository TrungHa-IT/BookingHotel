using HotelBooking.Models;
using HotelBooking.Repositories;
using HotelBooking.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HotelBooking.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceCategoriesRepositories _serviceCategoriesRepositories;
        private readonly IRoomRepositories _roomRepositories;
        private readonly ICategoriesRoomRepository _categoriesRoomRepositories;
        private readonly IServiceRepositories _serviceRepositories;
        private readonly IBlogRepositories _blogRepositories;
        public HomeController(
            IServiceCategoriesRepositories serviceCategoriesRepositories,
            IRoomRepositories roomRepositories, ICategoriesRoomRepository categoriesRoomRepository, IServiceRepositories serviceRepositories, IBlogRepositories blogRepositories)
        {
            _serviceCategoriesRepositories = serviceCategoriesRepositories;
            _roomRepositories = roomRepositories;
            _categoriesRoomRepositories = categoriesRoomRepository;
            _serviceRepositories = serviceRepositories;
            _blogRepositories = blogRepositories;
        }

        public async Task<IActionResult> Index()
        {
            var serviceCategories = await _serviceCategoriesRepositories.GetAllServiceCategoriesAsync();
            var rooms = await _roomRepositories.GetAllRoomAsync();
            var categoriesRooms = await _categoriesRoomRepositories.GetAllCategoriesRoomAsync();
            var service = await _serviceRepositories.GetAllServiceAsync();
            var blogs = await _blogRepositories.GetAllBlogAsync();

            var model = new HomeViewModel
            {
                ServiceCategories = serviceCategories,
                Room = rooms,
                CategoriesRoom = categoriesRooms,
                services = service,
                Blog = blogs
            };

            return View(model);
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
