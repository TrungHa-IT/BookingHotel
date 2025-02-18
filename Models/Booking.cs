using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime? CheckIn { get; set; }

        public DateTime? CheckOut { get; set; }

        [Required]
        public int QuantityRoom { get; set; }

        [Required]
        public int QuantityAdult { get; set; }

        [Required]
        public int QuantityChildren { get; set; }

        [Required]
        public int QuantityInfants { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? ConfirmEmail { get; set; }

        [Required]
        public string? Phone { get; set; }

        public string? Message { get; set; }

        [Required]
        public DateTime? PlannedArrivalDate { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public DateTime? CreateAt { get; set; }

        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }

        public virtual AppUser? User { get; set; }

        public int ExtrasId { get; set; }

        public int VoucherId { get; set; }

        [ForeignKey("Payment")]
        public int PaymentId { get; set; }

        public virtual Payment? Payment { get; set; }

        // Quan hệ nhiều với BookAble
        public virtual ICollection<BookAble>? BookAbles { get; set; }
    }
}
