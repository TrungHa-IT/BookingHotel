using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class HotelImage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ImageURL { get; set; }
    }
}
