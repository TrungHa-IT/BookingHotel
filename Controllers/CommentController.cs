using HotelBooking.Models;
using HotelBooking.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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

        public IActionResult Like()
        {
            return RedirectToAction("Detail", "Blog");
        }

        public IActionResult ReplyComment()
        {
            return RedirectToAction("Detail", "Blog");
        }

        public IActionResult CreateComment()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateComment(Comments comments, int BlogId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                var returnUrl = Url.Action("Detail", "Blog", new { id = BlogId });
                return RedirectToAction("Login", "Account", new { returnUrl });
            }

            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                comments.AppUserId = userId;
                comments.CreatedDate = DateTime.Now;
                comments.BlogId = BlogId;
                comments.Likes = 0;
                await _commentRepositories.CreateCommentAsync(comments);

                return RedirectToAction("Detail", "Blog", new { id = BlogId });
            }

            return RedirectToAction("Index", "Blog");
        }


    }
}
