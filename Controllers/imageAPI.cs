using HotelBooking.Models;
using HotelBooking.Repositories;
using HotelBooking.Services;
using HotelBooking.Utils.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

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
        public async Task<IActionResult> Create(List<IFormFile> files, int relationID)
        {
            if (files == null || files.Count == 0)
            {
                ModelState.AddModelError("files", "Please select at least one image to upload.");
                return BadRequest(ModelState);
            }

            try
            {
                await _imageRepositories.CreateImageAsync(files, relationID, Constants.room);
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

        [HttpPost]
        [Route("UpdateAllImage")]

        public async Task<IActionResult> UpdateAllImage(List<IFormFile> files,int relationID){
           if(files == null || files.Count == 0){
            ModelState.AddModelError("files", "Please select at least one image to upload.");
                return BadRequest(ModelState);
           }
           try
           {
            await _imageRepositories.UpdateAllImage(files, Constants.room, relationID);
            return Ok();
           }
           catch (Exception ex) 
           {
                return StatusCode(500, ex.Message);
           }
        }
    }
}
