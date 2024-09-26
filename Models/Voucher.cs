using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class Voucher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Percentage { get; set; }
        [Required]
        public DateOnly CreateAt { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateOnly ExpiryDate { get; set; }
        [Required]
        public int Status { get; set; }
    }
}
