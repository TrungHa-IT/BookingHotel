using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }  // Khóa chính

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Inclusions { get; set; }  // Mô tả phòng

        [Required]
        public string? Description { get; set; }  // Mô tả phòng

        [Required]
        public string? Amenities { get; set; }  // Các tiện nghi của phòng

        [Required]
        public string? CheckInOut { get; set; }  // Thời gian check-in/check-out

        public string? Others { get; set; }  // Các thông tin khác

        [Required]
        public string? Features { get; set; }  // Các đặc điểm nổi bật của phòng

        [Required]
        public DateTime? CreateAt { get; set; }  // Thời gian tạo phòng

        [Required]
        public int Status { get; set; }  // Trạng thái của phòng (1: hoạt động, 0: không hoạt động)

        [Required]
        public int QuantityRoom { get; set; }

        [Required]
        public int MaxAdultPeople { get; set; }

        [Required]
        public int MaxChildrenPeople {  get; set; }
        public int VoucherId { get; set; }  // Khóa ngoại từ bảng Voucher
        // Khóa ngoại liên kết đến bảng CategoriesRoom
        public int CategoryID { get; set; }  // Khóa ngoại từ bảng CategoriesRoom

        public virtual ICollection<BookAble?> BookAbles { get; set; }  // Danh sách các bản ghi trong bảng BookAble

    }

}
