using HotelBooking.Models;
using HotelBooking.Repositories;
using HotelBooking.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class imageAPI : ControllerBase
    {
        private readonly IImageRepositories _imageRepositories;
      

        public imageAPI(IImageRepositories imageRepositories, ICloudinaryService cloudinaryService)
        {
            _imageRepositories = imageRepositories;
        }

        [HttpPost]
        [Route("Create")]


        public async Task<IActionResult> Create(List<IFormFile> files, int relationID, string relation)
        {
            if (files == null || files.Count == 0)
            {
                ModelState.AddModelError("files", "Please select at least one image to upload.");
                return BadRequest(ModelState);
            }

            try
            {
               await _imageRepositories.CreateImageAsync(files, relationID, relation);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllByRID")]
        public async Task<IActionResult> GetAllByRID(int relationID, string relation)
        {
            try
            {
                var images = await _imageRepositories.GetAllImageByIdOfRelationID(relationID, relation);
                return Ok(images);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
