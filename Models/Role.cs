using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }
        [Required] 
        public string RoleUser {  get; set; }
        public int Status { get; set; } 
    }
}
