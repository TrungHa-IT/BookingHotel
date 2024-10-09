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
        public int status { get; set; }
        //Khoa ngoai User
        public int user_id { get; set; }
        public virtual AppUser? User { get; set; }
        //khoa ngoai voucher
        public int voucherID {  get; set; }
        public virtual Voucher? Voucher { get; set; }
        //khoa ngoai room
        public int room_id {  get; set; }
        public virtual Room? Room { get; set; }
        //khoa ngoai detail
        public int detail_id { get; set; }
        public virtual BookingDetail? BookingDetail { get; set; }    
    }
}
