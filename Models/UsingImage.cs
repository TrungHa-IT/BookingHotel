using HotelBooking.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Models
{
    public class UsingImage
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [ForeignKey("Service")]  // Thêm thuộc tính ForeignKey
        public int ServiceID { get; set; }

        [ForeignKey("UsingType")]
        public int TypeID { get; set; }
        public virtual UsingType? UsingType { get; set; }

        [ForeignKey("Image")]
        public int ImageID { get; set; }
        public virtual Image? Image { get; set; }

        public virtual Service? Service { get; set; }  // Điều hướng đến Service
    }
}
