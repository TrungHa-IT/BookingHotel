using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Models
{
    public class BookingService
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? fullname { get; set; }
        [Required]
        public string? phone_number {  get; set; }
        [Required]
        public string? email { get; set; }
        [Required]
        public DateTime? date {  get; set; }
        [Required]
        public int number_person { get; set; }

        [Required]
        public DateTime? start_time { get; set; }

        [Required]
        public DateTime? end_time { get; set; }

        [Required]
        public string message { get; set; }
        [ForeignKey("Service")]
        public int ServiceID { get; set; }

        // Điều hướng đến ServiceCategories
        public virtual Service Service { get; set; }
    }
}
