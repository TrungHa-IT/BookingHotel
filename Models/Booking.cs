using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime? check_in { get; set; }
        [Required]
        public DateTime? check_out { get; set; }
        [Required]
        public int quantity_room { get; set; }
        [Required]
        public int quantity_adult { get; set; }
        [Required]
        public int quantity_children { get; set; }
        [Required]
        public int quantity_infants { get; set; }
        [Required]
        public string? first_name { get; set; }
        [Required]
        public string? last_name { get; set; }
        [Required]
        public string? email { get; set; }
        [Required]
        public string? confirm_email { get; set; }
        [Required]
        public string? phone { get; set; }
        [Required]
        public string? message { get; set; }
        [Required]
        public DateTime? plannedArrivalDate { get; set; }
        [Required]
        //khoa ngoai payment
        public int payment_id { get; set; }
        [Required]
        public int extras_id { get; set; }
        [Required]
        public int status { get; set; }
        //Khoa ngoai User
        public int user_id { get; set; }
        //khoa ngoai voucher
        public int voucherID {  get; set; }
        public virtual ICollection<BookAble?> BookAbles { get; set; }  // Danh sách các bản ghi trong bảng BookAble

    }
}
