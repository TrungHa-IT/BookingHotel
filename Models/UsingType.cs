using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class UsingType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }  // Ví dụ: "Service", "CategoriesRoom"

        public virtual ICollection<UsingImage>? UsingImages { get; set; }
    }
}
