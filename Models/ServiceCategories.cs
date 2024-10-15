using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Models
{
    public class ServiceCategories
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public DateTime? CreateAt { get; set; }
        [Required]
        public int? Status { get; set; }
        // Thiết lập quan hệ 1-1 với Service
        public virtual ICollection<Service>? Services { get; set; }  // Danh sách các Service thuộc Category này
    }
}
