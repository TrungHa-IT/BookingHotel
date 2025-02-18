using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Credit { get; set; }
        public virtual ICollection<Booking>? Bookings { get; set; }
    }
}
