using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }  // Khóa chính

        [Required]
        public string? Description { get; set; }  // Mô tả phòng

        [Required]
        public string? Amenities { get; set; }  // Các tiện nghi của phòng

        [Required]
        public DateTime? CheckInOut { get; set; }  // Thời gian check-in/check-out

        public string? Others { get; set; }  // Các thông tin khác

        [Required]
        public string? Features { get; set; }  // Các đặc điểm nổi bật của phòng

        [Required]
        public DateTime? CreateAt { get; set; }  // Thời gian tạo phòng

        [Required]
        public int Status { get; set; }  // Trạng thái của phòng (1: hoạt động, 0: không hoạt động)

        // Khóa ngoại liên kết đến bảng Voucher
        [ForeignKey("Voucher")]
        public int VoucherId { get; set; }  // Khóa ngoại từ bảng Voucher

        public virtual Voucher? Voucher { get; set; }  // Điều hướng đến bảng Voucher

        // Khóa ngoại liên kết đến bảng CategoriesRoom
        [ForeignKey("CategoriesRoom")]
        public int CategoryID { get; set; }  // Khóa ngoại từ bảng CategoriesRoom

        public virtual CategoriesRoom? CategoriesRoom { get; set; }  // Điều hướng đến bảng CategoriesRoom

        // Mối quan hệ 1-nhiều với bảng UsingImage
        public virtual ICollection<UsingImage>? UsingImages { get; set; }  // Một Room có thể có nhiều ảnh
    }

}
