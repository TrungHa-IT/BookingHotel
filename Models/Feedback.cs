using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Content { get; set; }
        [Required]
        public int Star {  get; set; }
        [Required]
        public DateTime? CreateAt { get; set; }
        public int user_id { get; set; }
        public virtual AppUser? User { get; set; }

        public int room_id { get; set; }
        public virtual Room? Room { get; set; }
        public virtual ICollection<UsingImage>? UsingImages { get; set; }  // Một CategoriesRoom có thể có nhiều ảnh
    }
}
