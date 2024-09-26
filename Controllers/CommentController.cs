using HotelBooking.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentsRepositories _commentRepositories;

        public CommentController(ICommentsRepositories commentRepositories)
        {
            _commentRepositories = commentRepositories;
        }
        // GET: Categories
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10, string searchName = "")
        {
            var categories = await _commentRepositories.GetCommentPagedAsync(pageNumber, pageSize, searchName);
            return View(categories);
        }
    }
}
