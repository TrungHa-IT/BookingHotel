using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Models
{
    public class Image
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string imageURL { get; set; }

        [Required]
        public DateTime create_at { get; set; }

        [Required]
        public EntityType entity_type { get; set; } // Dùng enum cho entity_type
        [ForeignKey("Service")]
        public int service_id { get; set; }
        public virtual  Service Service  { get; set; }
    }

    // Khai báo enum cho entity_type
    public enum EntityType
    {
        Hotel,
        Room,
        Service,
        Slider
    }
}
