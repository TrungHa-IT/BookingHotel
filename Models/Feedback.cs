using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int Star {  get; set; }
        [Required]
        public DateOnly CreateAt { get; set; }
        [Required]
        public string Image {  get; set; }
    }
}
