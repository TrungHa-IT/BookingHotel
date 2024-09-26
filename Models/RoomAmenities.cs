using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class RoomAmenities
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateOnly CreateAt { get; set; }  
    }
}
