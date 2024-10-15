using System.ComponentModel.DataAnnotations;

namespace HotelBooking.ViewModels
{
    public class ServiceCategoriesVM
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public DateTime? CreateAt { get; set; }
    }
}
