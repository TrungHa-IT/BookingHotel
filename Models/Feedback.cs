using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        // Thêm ngoại khóa UsingImageID
        [ForeignKey("UsingImage")]
        public int UsingImageID { get; set; }
        public virtual UsingImage? UsingImage { get; set; }
    }
}
