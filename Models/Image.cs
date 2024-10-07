using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Models
{
    public class Image
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string? imageURL { get; set; }

        [Required]
        public string? name { get; set; }

        [Required]
        public DateTime? create_at { get; set; }

        public ICollection<UsingImage>? UsingImages { get; set; }
    }
}
