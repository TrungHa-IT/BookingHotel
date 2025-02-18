using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Models
{
    public class BookAble
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Booking")]
        public int BookingId { get; set; }  // Khóa ngoại từ bảng Booking

        [ForeignKey("Room")]
        public int RoomId { get; set; }  // Khóa ngoại từ bảng Room

        public DateTime? DateTime { get; set; }  // Thời gian đặt phòng

        public int Status { get; set; }  // Trạng thái (ví dụ: đã xác nhận, hủy, ...)

        public virtual Booking? Booking { get; set; }  // Điều hướng đến bảng Booking
        public virtual Room? Room { get; set; }  // Điều hướng đến bảng Room
    }
}
