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
       private readonly IImageRepositories _imageRepositories;
        public RoomController(IRoomRepositories roomRepositories, ICategoriesRoomRepository categoriesRoomRepository, IImageRepositories imageRepositories)
        {
            _roomRepositories = roomRepositories;
            _categoriesRoomRepository = categoriesRoomRepository;
            _imageRepositories = imageRepositories;
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
        public async Task<IActionResult> Create(RoomViewModel roomVM)
        {
            Room room = GetRoom(roomVM);


            if (room.Features == null)
            {
                room.Features = "Default";
            }
            await _roomRepositories.CreateRoomAsync(room);
            await _imageRepositories.CreateImageAsync(roomVM.Images, room.Id, "Room");
            return RedirectToAction(nameof(Index));
        }

        private static Room GetRoom(RoomViewModel roomVM)
        {
            return new Room
            {
                Amenities = roomVM.Amenities,
                CategoryID = roomVM.CategoryID,
                CheckInOut = roomVM.CheckInOut,
                Description = roomVM.Description,
                Features = roomVM.Features,
                Inclusions = roomVM.Inclusions,
                MaxAdultPeople = roomVM.MaxAdultPeople,
                MaxChildrenPeople = roomVM.MaxChildrenPeople,
                Name = roomVM.Name,
                Others = roomVM.Others,
                QuantityRoom = roomVM.Quantity,
                CreateAt = DateTime.Now,
                VoucherId = 1,
                Status = 1
            };
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
