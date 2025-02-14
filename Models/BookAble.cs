using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class BookAble
    {
        [Key]
        public int Id { get; set; }
        public int BookingsId { get; set; }
        public int RoomId { get; set; }
        public DateTime? DateTime { get; set; }
        public int Status { get; set; }
    }
}
