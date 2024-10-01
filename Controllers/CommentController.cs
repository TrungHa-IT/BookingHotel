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

        public IActionResult CreateComment()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateComment(Comments comments, int BlogId)
        {
            // Kiểm tra xem người dùng đã đăng nhập hay chưa
            if (!User.Identity.IsAuthenticated)
            {
                // Nếu chưa đăng nhập, chuyển hướng đến trang đăng nhập hoặc thông báo lỗi
                return RedirectToAction("Login", "Account"); // Chuyển hướng đến trang đăng nhập
            }

            // Nếu đã đăng nhập, tiến hành lưu bình luận vào CSDL
            if (ModelState.IsValid)
            {

                // Lưu vào cơ sở dữ liệu (giả sử bạn có DbContext đã được thiết lập)
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);  // Get current user's ID
                comments.AppUserId = userId;
                comments.CreatedDate = DateTime.Now;
                comments.BlogId = BlogId; // Gán BlogId từ yêu cầu
                await _commentRepositories.CreateCommentAsync(comments);

                return RedirectToAction("Index", "Blog"); // Chuyển hướng đến danh sách blog sau khi tạo bình luận
            }

            // Nếu Model không hợp lệ, trở lại trang tạo bình luận với thông tin hiện tại
            return RedirectToAction("Index", "Blog");
        }

    }
}
