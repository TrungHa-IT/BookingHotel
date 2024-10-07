using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }  // Khóa chính

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public string? Duration { get; set; }

        [Required]
        public string? Inclusions { get; set; }

        [Required]
        public string? Reason { get; set; }

        [Required]
        public string? Terms { get; set; }

        [Required]
        public DateTime? CreateAt { get; set; }

        [Required]
        public int? Status { get; set; }

        // Thiết lập khóa ngoại đến ServiceCategories (quan hệ nhiều Service với 1 ServiceCategories)
        [ForeignKey("ServiceCategories")]
        public int ServiceCategoriesID { get; set; }

        // Điều hướng đến ServiceCategories
        public virtual ServiceCategories? ServiceCategories { get; set; }
        public virtual ICollection<Image>? Images { get; set; }  // Danh sách các Service thuộc Category này
        public virtual BookingService? BookingService { get; set; }
    }
}
