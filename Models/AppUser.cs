using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class AppUser : IdentityUser
    {
        [StringLength(100)]
        [MaxLength(100)]
        [Required]
        public string? Name { get; set; }

        public string? Address { get; set; }

        // Thuộc tính điều hướng tới Blog (1 AppUser có nhiều Blog)
        public ICollection<Blog> Blogs { get; set; }
        // Thuộc tính điều hướng tới Blog (1 AppUser có nhiều Comments)
        public ICollection<Comments> Comments { get; set; }
    }
}
