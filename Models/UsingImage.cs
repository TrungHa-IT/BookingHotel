using HotelBooking.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Models
{
    public class UsingImage
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("UsingType")]
        public int TypeID { get; set; }  // Xác định loại đối tượng (Service, CategoriesRoom)
        public virtual UsingType? UsingType { get; set; }

        [ForeignKey("Image")]
        public int ImageID { get; set; }  // Khóa ngoại liên kết đến bảng Image
        public virtual Image? Image { get; set; }

        public int RID { get; set; }
    }
}
