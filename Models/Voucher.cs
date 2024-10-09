using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class Voucher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? code { get; set; }
        [Required]
        public double discount { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTime? ExpiryDate { get; set; }
        [Required]
        public DateTime? CreateAt { get; set; }
        [Required]
        public int Status { get; set; }

        //dieu huong
        public virtual Booking? Booking { get; set; }    
        public virtual Room? Room { get; set; }
    }
}
