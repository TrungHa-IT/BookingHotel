using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class RoomImage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ImageURL { get; set; }
    }
}
