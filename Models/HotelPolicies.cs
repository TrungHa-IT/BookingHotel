using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class HotelPolicies
    {
        [Key]
        public int Id;
        [Required]
        public string Name;
        [Required]
        public string Content;
        [Required]
        public int Status;
        [Required]
        public DateOnly CreateAt;
    }
}
