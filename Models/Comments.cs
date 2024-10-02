using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class Comments
    {
        [Key]
        public int CommentID { get; set; }

        [Required]
        public string? Content { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        // Cho phép null khi không có comment cha (bình luận gốc)
        public int? ParentCommentID { get; set; }

        // Like or Star the comment
        public int? Likes {  get; set; }

        // Khóa ngoại tới AppUser (người bình luận)
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

        // Khóa ngoại tới Blog (bài viết mà bình luận thuộc về)
        public int? BlogId { get; set; } // Sửa thành int
        public Blog? Blog { get; set; } // Sửa tên thành Blog

        // Thuộc tính điều hướng tới Comment cha (nếu có)
        public Comments? ParentComment { get; set; }

        // Thuộc tính điều hướng tới các bình luận con (reply)
        public ICollection<Comments> Replies { get; set; }
        // Thuộc tính điều hướng tới các bình luận con (reply)
        // Điều hướng tới danh sách LikeRecord
        public ICollection<LikeRecord> LikeRecords { get; set; }

        public Comments()
        {
            Replies = new List<Comments>(); // Khởi tạo để tránh null
            LikeRecords = new List<LikeRecord>(); // Khởi tạo để tránh null
        }
    }


}
