using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Content { get; set; }

        [Required]
        public string? Thumbnail { get; set; }

        [Required]
        public string? BriefInfor { get; set; }

        [Required]
        public DateTime CreateAt { get; set; }

        [Required]
        public DateTime UpdateAt { get; set; }

        [Required]
        public int Status { get; set; }

        // Khóa ngoại tới AppUser
        public string? AppUserId { get; set; }

        // Thuộc tính điều hướng tới AppUser
        public virtual AppUser? AppUser { get; set; }

        // Thuộc tính điều hướng tới các bình luận của Blog
        public virtual ICollection<Comments> Comments { get; set; } = new List<Comments>();
    }


}
