using HotelBooking.Models;
using HotelBooking.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace HotelBooking.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageRepositories _imageRepositories;
        public ImageController(IImageRepositories imageRepositories)
        {
            _imageRepositories = imageRepositories;
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(List<IFormFile> images)
        {
            
            int typeId = 0, relationId = 0;
            await _imageRepositories.CreateImagesAsync(relationId, typeId, images);
            return RedirectToAction("Index","Image");
        }
        public async Task<IActionResult> Index()
        {
            var display = await _imageRepositories.GetAllImageAsync();
            return View(display);
        }
    }
}
