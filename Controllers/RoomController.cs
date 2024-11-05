using HotelBooking.Models;
using HotelBooking.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepositories _roomRepositories;

        public RoomController(IRoomRepositories roomRepositories)
        {
            _roomRepositories = roomRepositories;
        }
        public async Task<IActionResult> Index()
        {
            var display = await _roomRepositories.GetAllRoomAsync();
            return View(display);
        }

        //Create/CategoriesRoom
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Room room)
        {
            if (!ModelState.IsValid)
            {
                room.CreateAt = DateTime.Now;
                await _roomRepositories.CreateRoomAsync(room);
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }
        //Details/CategoriesRoom
        public async Task<IActionResult> Details(int id)
        {
            var categoriesRoom = await _roomRepositories.GetRoomByIdAsync(id);
            return categoriesRoom == null ? NotFound() : View(categoriesRoom);
        }
        //Edits/CategoriesRoom
        public async Task<IActionResult> Edit(int id)
        {
            var categoriesRoom = await _roomRepositories.GetRoomByIdAsync(id);
            return categoriesRoom == null ? NotFound() : View(categoriesRoom);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Room room)
        {
            await _roomRepositories.UpdateRoomAsync(room);
            return RedirectToAction(nameof(Index));
        }
        //Delete/CategoriesRoom
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriesRoom = await _roomRepositories.GetRoomByIdAsync(id);
            if (categoriesRoom == null) return NotFound();
            await _roomRepositories.DeleteRoomAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
