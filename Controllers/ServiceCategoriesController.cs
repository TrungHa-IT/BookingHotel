using HotelBooking.Models;
using HotelBooking.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HotelBooking.Controllers
{
    public class ServiceCategoriesController : Controller
    {
        private readonly IServiceCategoriesRepositories _serviceCategoriesRepositories;

        public ServiceCategoriesController(IServiceCategoriesRepositories serviceCategoriesRepositories)
        {
            _serviceCategoriesRepositories = serviceCategoriesRepositories;

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
