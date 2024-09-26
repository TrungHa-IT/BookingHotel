using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class Comments
    {
        [Key]
        public int CommentID { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        // Cho phép null khi không có comment cha (bình luận gốc)
        public int? ParentCommentID { get; set; }

        // Khóa ngoại tới AppUser (người bình luận)
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        // Thuộc tính điều hướng tới Comment cha (nếu có)
        public Comments ParentComment { get; set; }

        // Thuộc tính điều hướng tới các bình luận con (reply)
        public ICollection<Comments> Replies { get; set; }
    }

}
