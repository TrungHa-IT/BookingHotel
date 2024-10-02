namespace HotelBooking.Models
{
    public class LikeRecord
    {
        public int LikeRecordId { get; set; }

        // Khóa ngoại tham chiếu đến bảng Comment
        public int CommentId { get; set; }
        public virtual Comments Comment { get; set; }  // Điều hướng đến Comment

        // Khóa ngoại tham chiếu đến bảng User
        public string UserId { get; set; }  // ID của tài khoản đã like
        public virtual AppUser User { get; set; }  // Điều hướng đến User

        public DateTime LikedAt { get; set; }
    }
}
