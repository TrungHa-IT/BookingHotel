using HotelBooking.Repositories;
using Microsoft.AspNetCore.Mvc;
using HotelBooking.Models;
namespace HotelBooking.Controllers
{
    public class CategoriesRoomController : Controller
    {
        private readonly ICategoriesRoomRepositories _categoriesRoomRepositories;
        private readonly IImageRepositories _imageRepositories;


        public CategoriesRoomController(ICategoriesRoomRepositories serviceCategoriesRepositories, IImageRepositories imageRepositories)
        {
            _categoriesRoomRepositories = serviceCategoriesRepositories;
            _imageRepositories = imageRepositories;
        }


        public async Task<IActionResult> Index()
        {
            var sc = await _categoriesRoomRepositories.GetAllCategoriesRoomAsync();
            return View(sc);
        }

        #region CategoriesRoom Create Item

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoriesRoom categoriesRoom)
        {

            categoriesRoom.Create_At = DateTime.Now;
            await _categoriesRoomRepositories.CreateCategoriesRoomAsync(categoriesRoom);
            return RedirectToAction("Index", "CategoriesRoom");
        }
        #endregion

        #region Detail Item

        public async Task<IActionResult> Detail(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var sc = await _categoriesRoomRepositories.GetCategoriesRoomByIdAsync(id.Value);
            if(sc == null)
            {
                return NotFound();
            }
            return View(sc);
        }
        #endregion
    }
}
