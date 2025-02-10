using HotelBooking.Models;
using HotelBooking.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageRepositories _imageRepositories;

        public ImageController(IImageRepositories imageRepositories)
        {
            _imageRepositories = imageRepositories;
        }
        public async Task<IActionResult> Index()
        {
            var display = await _imageRepositories.GetAllImagesAsync();
            return View();
        }

        //Create/Image
        public IActionResult Create()
        {
            return View();
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Image image)
        {
            if (!ModelState.IsValid)
            {
                image.create_at = DateTime.Now;
                image.RID = 1;
                await _imageRepositories.CreateImageAsync(image);
                return RedirectToAction(nameof(Index));
            }
            return View(image);
        }
    }
}
