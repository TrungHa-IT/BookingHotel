using HotelBooking.Models;
using HotelBooking.Repositories;
using HotelBooking.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers
{
  
    public class ImageController : Controller
    {
        private readonly IImageRepositories _imageRepositories;
        private readonly ICloudinaryService _icloudinaryService;
        public ImageController(IImageRepositories imageRepositories, ICloudinaryService cloudinaryService)
        {
            _imageRepositories = imageRepositories;
            _icloudinaryService = cloudinaryService;
        }
        public async Task<IActionResult> Index()
        {
            var display = await _imageRepositories.GetAllImagesAsync();
            return View(display);
        }

        // GET: Create Image
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create Image
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("file", "error");
                return View();
            }

            try
            {
                Image image = new Image
                {
                    create_at = DateTime.Now,
                    RID = 1, 
                    imageURL = await _icloudinaryService.UploadImageAsync(file) ,
                    name = file.FileName
                };

                await _imageRepositories.CreateImageAsync(image);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"error: {ex.Message}");
                return View();
            }
        }
    }
}
