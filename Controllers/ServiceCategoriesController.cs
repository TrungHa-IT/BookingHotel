using HotelBooking.Models;
using HotelBooking.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HotelBooking.Controllers
{
    public class ServiceCategoriesController : Controller
    {
        private readonly IServiceCategoriesRepositories _serviceCategoriesRepositories;
        private readonly IImageRepositories _imageRepositories;

        public ServiceCategoriesController(IServiceCategoriesRepositories serviceCategoriesRepositories, IImageRepositories imageRepositories)
        {
            _serviceCategoriesRepositories = serviceCategoriesRepositories;
            _imageRepositories = imageRepositories;
        }

        public async Task<IActionResult> Index()
        {
            var sc = await _serviceCategoriesRepositories.GetAllServiceCategoriesAsync();
            return View(sc);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceCategories serviceCategories)
        {
            
                serviceCategories.CreateAt = DateTime.Now;
                await _serviceCategoriesRepositories.CreateServiceCategoriesAsync(serviceCategories);
                await _imageRepositories.CreateServiceCategoriesAsync(serviceCategories);
                return RedirectToAction("Index", "ServiceCategories");
            
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sc = await _serviceCategoriesRepositories.GetServiceCategoriesByIdAsync(id.Value);
            if (sc == null)
            {
                return NotFound();
            }

            return View(sc);
        }
    }
}
