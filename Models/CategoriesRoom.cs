using System.ComponentModel.DataAnnotations;

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

        // Mối quan hệ 1-nhiều với UsingImage
        public virtual ICollection<UsingImage>? UsingImages { get; set; }  // Một CategoriesRoom có thể có nhiều ảnh
    }
}
