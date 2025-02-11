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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(List<IFormFile> files, int relationID, string relation) // Accept multiple files
        {
            if (files == null || files.Count == 0)
            {
                ModelState.AddModelError("files", "Please select at least one image to upload.");
                return View();
            }

            try
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        // Create and populate the Image entity
                        Image image = new Image
                        {
                            create_at = DateTime.Now,
                            RID = 1, // Set your specific RID value
                            imageURL = await _icloudinaryService.UploadImageAsync(file), // Upload file to cloud
                            name = file.FileName // Use original file name or generate a new one
                        };

                        // Save image to the database
                        await _imageRepositories.CreateImageAsync(image);
                    }
                }

                // Redirect to the index or another view
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
                return View();
            }
        }

    }
}
