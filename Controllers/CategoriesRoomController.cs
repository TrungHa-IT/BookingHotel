using HotelBooking.Models;
using HotelBooking.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers
{
    public class CategoriesRoomController : Controller
    {
        private readonly ICategoriesRoomRepository _categoriesRoomRepository;

        public CategoriesRoomController(ICategoriesRoomRepository categoriesRoomRepository)
        {
            _categoriesRoomRepository = categoriesRoomRepository;
        }
        public async Task<IActionResult> Index()
        {
            var display = await _categoriesRoomRepository.GetAllCategoriesRoomAsync();
            return View(display);
        }

        //Create/CategoriesRoom
        public IActionResult Create()
        {
             return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (CategoriesRoom categoriesRoom)
        {
            if (!ModelState.IsValid)
            {   categoriesRoom.Create_At = DateTime.Now;
                await _categoriesRoomRepository.CreateCategoriesRoomAsync(categoriesRoom);
                return RedirectToAction(nameof(Index));
            }
            return View(categoriesRoom);
        }
        //Details/CategoriesRoom
        public async Task<IActionResult> Details(int id)
        {
            var categoriesRoom = await _categoriesRoomRepository.GetCategoriesRoomByIdAsync(id);
            return categoriesRoom == null ? NotFound() : View(categoriesRoom);
        }
        //Edits/CategoriesRoom
        public async Task<IActionResult> Edit(int id)
        {
            var categoriesRoom = await _categoriesRoomRepository.GetCategoriesRoomByIdAsync(id);
            return categoriesRoom == null ? NotFound() : View(categoriesRoom);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoriesRoom categoriesRoom)
        {    
                await _categoriesRoomRepository.UpdateCategoriesRoomAsync(categoriesRoom);
                return RedirectToAction(nameof(Index));
        }
        //Delete/CategoriesRoom
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriesRoom = await _categoriesRoomRepository.GetCategoriesRoomByIdAsync(id);
            if(categoriesRoom == null) return NotFound();
            await _categoriesRoomRepository.DeleteCategoriesRoomAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
