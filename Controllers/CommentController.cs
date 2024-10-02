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
        private readonly ILikeRecordRepositories _likeRecordRepository;

        public CommentController(ICommentsRepositories commentRepositories, ILikeRecordRepositories likeRecordRepositories)
        {
            _commentRepositories = commentRepositories;
            _likeRecordRepository = likeRecordRepositories;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Like(int commentId, int blogId)
        {
            // Lấy thông tin người dùng hiện tại (giả sử bạn có hệ thống đăng nhập)
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized(); // Chuyển hướng nếu người dùng chưa đăng nhập
            }

            // Lấy bình luận theo ID
            var comment = await _commentRepositories.GetCommentByIdAsync(commentId);

            if (comment != null)
            {
                // Kiểm tra xem người dùng đã like bình luận này chưa
                var likeRecord = await _likeRecordRepository.GetLikeRecordByIdAsync(commentId, userId);

                if (likeRecord != null)
                {
                    // Người dùng đã like => Thực hiện sUnlike (hủy like)
                    await _likeRecordRepository.DeleteLikeRecordAsync(likeRecord);
                    comment.Likes--; // Giảm số lượt like
                }
                else
                {
                    // Người dùng chưa like => Thực hiện Like
                    var newLikeRecord = new LikeRecord
                    {
                        CommentId = commentId,
                        UserId = userId,
                        LikedAt = DateTime.Now
                    };
                    await _likeRecordRepository.CreateLikeRecordAsync(newLikeRecord);
                    comment.Likes++; // Tăng số lượt like
                }

                // Cập nhật bình luận trong cơ sở dữ liệu
                await _commentRepositories.UpdateCommentAsync(comment);

                // Chuyển hướng trở lại trang chi tiết Blog
                return RedirectToAction("Detail", "Blog", new { id = blogId });
            }

            // Nếu bình luận không tồn tại, bạn có thể chuyển hướng hoặc xử lý lỗi
            return NotFound();
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
                return Json(new { success = false, redirectUrl = Url.Action("Login", "Account", new { returnUrl }) });
            }

            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                comments.AppUserId = userId;
                comments.CreatedDate = DateTime.Now;
                comments.BlogId = BlogId;
                comments.Likes = 0;
                await _commentRepositories.CreateCommentAsync(comments);

                // Optionally return the created comment object as JSON
                return Json(new { success = true, comment = comments });
            }

            return Json(new { success = false });
        }


        // Hàm kiểm tra xem người dùng đã thích bình luận hay chưa
        public async Task<bool> UserHasLikedCommentAsync(int commentId, string userId)
        {
            // Kiểm tra xem bản ghi like tồn tại với commentId và userId hay không
            var likeRecord = await _likeRecordRepository.GetLikeRecordByIdAsync(commentId, userId);
            return likeRecord != null; // Nếu tồn tại likeRecord thì trả về true
        }
    }
}
