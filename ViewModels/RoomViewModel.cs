using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.ViewModels
{
    public class RoomViewModel
    {
        [Required]
        public string Description { get; set; }

        public string Amenities { get; set; }

        public string CheckInOut { get; set; }

        public string Others { get; set; }

        public string Features { get; set; }

        // Selected Category ID
        [Display(Name = "Category")]
        public int? CategoryID { get; set; }
        public SelectList CategoryList { get; set; }
    }
}

