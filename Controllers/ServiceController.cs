using HotelBooking.Models;
using HotelBooking.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceRepositories _serviceRepositories;
        private readonly IServiceCategoriesRepositories _serviceCategoriesRepositories; // Thêm repository cho ServiceCategories

        public ServiceController(IServiceRepositories serviceRepositories, IServiceCategoriesRepositories serviceCategoriesRepositories)
        {
            _serviceRepositories = serviceRepositories;
            _serviceCategoriesRepositories = serviceCategoriesRepositories; // Inject ServiceCategoriesRepository
        }

        public async Task<IActionResult> Index()
        {
            var sc = await _serviceRepositories.GetAllServiceAsync();
            return View(sc);
        }

        public async Task<IActionResult> Create()
        {
            // Lấy danh sách ServiceCategories
            var serviceCategories = await _serviceCategoriesRepositories.GetAllServiceCategoriesAsync();

            // Sử dụng SelectList để hiển thị trong dropdown
            ViewData["ServiceCategoriesID"] = new SelectList(serviceCategories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Service service)
        {

            var serviceCategories = await _serviceCategoriesRepositories.GetAllServiceCategoriesAsync();
            ViewData["ServiceCategoriesID"] = new SelectList(serviceCategories, "Id", "Name", service.ServiceCategoriesID);
            service.CreateAt = DateTime.Now;
                await _serviceRepositories.CreateServicesAsync(service);
                return RedirectToAction("Index", "Service");
            
            // Nếu có lỗi, trả lại danh sách ServiceCategories
            

           
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _serviceRepositories.GetServiceByIdAsync(id.Value);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }
    }
}
