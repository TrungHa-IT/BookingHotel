using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class BookingDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? first_name { get; set; }
        [Required]
        public string? last_name { get;set; }
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
        public virtual Payment? Payment { get; set; }    
        //khoa ngoai extras_id
        public int extras_id { get; set; }
        public virtual Extras? Extras { get; set; }  
    }
}
