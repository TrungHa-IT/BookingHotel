using HotelBooking.Models;
using HotelBooking.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers
{
    public class LikeRecordController : Controller
    {

        private readonly ILikeRecordRepositories _likeRecordRepositories;

        public LikeRecordController(ILikeRecordRepositories likeRecordRepositories)
        {
            _likeRecordRepositories = likeRecordRepositories;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateLikeRecord(LikeRecord likeRecord)
        {
            await _likeRecordRepositories.CreateLikeRecordAsync(likeRecord);
            return View();
        }
    }
}
