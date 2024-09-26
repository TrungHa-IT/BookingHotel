using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateOnly DateFrom { get; set; }
        [Required]
        public DateOnly DateTo { get; set; }
        [Required]
        public int QuantityAdult { get; set; }
        [Required]
        public int QuantityChildren { get; set; }
        [Required]
        public int QuantityRoom { get; set; }
        [Required]
        public int Status { get; set; }
        //Fk UserID
        //Fk RoomID
    }
}
