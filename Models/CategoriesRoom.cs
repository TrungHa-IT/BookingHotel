using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Models
{
    public class CategoriesRoom
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public DateTime? Create_At { get; set; }

        // Mối quan hệ 1-nhiều với Room
        public virtual ICollection<Room>? Rooms { get; set; }  // Một CategoriesRoom có thể có nhiều Room
    }
}
