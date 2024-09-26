using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Thumbnail { get; set; }

        [Required]
        public string BriefInfor { get; set; }

        [Required]
        public DateOnly CreateAt { get; set; }

        [Required]
        public DateOnly UpdateAt { get; set; }

        [Required]
        public int Status { get; set; }

        // Khóa ngoại tới AppUser
        public string AppUserId { get; set; }

        // Thuộc tính điều hướng tới AppUser
        public AppUser AppUser { get; set; }
    }

}
