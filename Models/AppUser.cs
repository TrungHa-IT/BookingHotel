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

        public int numberOfBooking { get; set; }

        public int numberOfBlog { get; set; }

        // Thuộc tính điều hướng tới Blog (1 AppUser có nhiều Blog)
        public virtual ICollection<Blog> Blogs { get; set; }

        // Thuộc tính điều hướng tới Comments (1 AppUser có nhiều Comments)
        public virtual ICollection<Comments> Comments { get; set; }

        // Thuộc tính điều hướng tới LikeRecord (1 AppUser có nhiều lượt Like)
        public virtual ICollection<LikeRecord> LikeRecords { get; set; }

        public AppUser()
        {
            Blogs = new List<Blog>();
            Comments = new List<Comments>();
            LikeRecords = new List<LikeRecord>(); // Khởi tạo để tránh null
        }
    }
}
