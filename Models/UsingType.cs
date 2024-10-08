using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class UsingType
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string? Name { get; set; }

        // Navigation property for the "many" side
        public virtual UsingImage? UsingImages { get; set; }
    }
}
