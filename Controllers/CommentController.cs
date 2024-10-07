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
            // Kiểm tra xem người dùng có đăng nhập hay không
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Json(new { success = false, message = "User not logged in" });
            }

            // Tìm kiếm bình luận theo ID
            var comment = await _commentRepositories.GetCommentByIdAsync(commentId);
            if (comment != null)
            {
                // Kiểm tra xem người dùng đã like bình luận này chưa
                var likeRecord = await _likeRecordRepository.GetLikeRecordByIdAsync(commentId, userId);

                if (likeRecord != null)
                {
                    // Nếu đã like, thực hiện unlike
                    await _likeRecordRepository.DeleteLikeRecordAsync(likeRecord);
                    comment.Likes--; // Giảm số lượt like
                    await _commentRepositories.UpdateCommentAsync(comment);
                    return Json(new { success = true, liked = false }); // Trả về JSON khi hủy like
                }
                else
                {
                    // Nếu chưa like, thực hiện like
                    var newLikeRecord = new LikeRecord
                    {
                        CommentId = commentId,
                        UserId = userId,
                        LikedAt = DateTime.Now
                    };
                    await _likeRecordRepository.CreateLikeRecordAsync(newLikeRecord);
                    comment.Likes++; // Tăng số lượt like
                    await _commentRepositories.UpdateCommentAsync(comment);
                    return Json(new { success = true, liked = true }); // Trả về JSON khi like
                }
            }

            // Trả về lỗi nếu bình luận không tìm thấy
            return Json(new { success = false, message = "Comment not found" });
        }



        public IActionResult ReplyComment()
        {
            return RedirectToAction("Detail", "Blog");
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
                var userName = User.Identity.Name;

                comments.AppUserId = userId;
                comments.CreatedDate = DateTime.Now;
                comments.BlogId = BlogId;
                comments.Likes = 0;

                // Lưu bình luận vào cơ sở dữ liệu
                await _commentRepositories.CreateCommentAsync(comments);

                // Sau khi lưu, lấy ID của bình luận
                // Hoặc cách khác để lấy ID

                return Json(new
                {
                    success = true,
                    comment = new
                    {
                        CommentID = comments.CommentID, // Thêm ID của bình luận vào phản hồi
                        Content = comments.Content,
                        UserName = userName,
                        CreatedDate = comments.CreatedDate.ToString("yyyy-MM-ddTHH:mm:ss")
                    }
                });
            }

            return Json(new { success = false, message = "Failed to create comment." });
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
