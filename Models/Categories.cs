
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class Categories
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateOnly CreateAt { get; set; }
    }
}
