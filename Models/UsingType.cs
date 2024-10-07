using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class UsingType
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<UsingImage> UsingImages { get; set; }
    }
}
