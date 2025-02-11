using HotelBooking.Models;
using HotelBooking.Repositories;
using HotelBooking.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepositories _roomRepositories;
        private readonly ICategoriesRoomRepository _categoriesRoomRepository;
       
        public RoomController(IRoomRepositories roomRepositories, ICategoriesRoomRepository categoriesRoomRepository)
        {
            _roomRepositories = roomRepositories;
            _categoriesRoomRepository = categoriesRoomRepository;
        }
        public async Task<IActionResult> Index()
        {
            var display = await _roomRepositories.GetAllRoomAsync();
            return View(display);
        }

        //Display all rooms
        public async Task<IActionResult> All()
        {
            var display = await _roomRepositories.GetAllRoomAsync();
            return View(display);
        }

        //Create/CategoriesRoom
        public async Task<IActionResult> Create()
        {

            // Lấy danh sách ServiceCategories
            var roomCategories = await _categoriesRoomRepository.GetAllCategoriesRoomAsync();

            // Sử dụng SelectList để hiển thị trong dropdown
            ViewData["RoomCategoriesID"] = new SelectList(roomCategories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Room room)
        {
            
                room.CreateAt = DateTime.Now;
                room.VoucherId = 2;
                room.Status = 1;
                if(room.Features == null)
            {
                room.Features = "Default";
            }
                await _roomRepositories.CreateRoomAsync(room);

                return RedirectToAction(nameof(Index));
        }
        //Details/CategoriesRoom
        public async Task<IActionResult> Details(int id)
        {
            var categoriesRoom = await _roomRepositories.GetRoomByIdAsync(id);
            return View(categoriesRoom);
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
