using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public string? Content { get; set; }

        [Required]
        public DateTime Create_At { get; set; }

        [Required]
        public int? Status { get; set; }

        [ForeignKey("ServiceCategories")]
        public int ServiceCategoriesID { get; set; }
        public virtual ServiceCategories? ServiceCategories { get; set; }
    }
}
