using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.ViewModels
{
    public class RoomViewModel
    {
        [Required]
        public string Name { get; set; }


        public string? Description { get; set; }

        public string? Inclusions { get; set; }

        public string? Amenities { get; set; }

        public string? CheckInOut { get; set; }

        public string? Others { get; set; }

        public string? Features { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int MaxAdultPeople { get; set; }

        [Required]
        public int MaxChildrenPeople { get; set; }

        // Selected Category ID
        [Display(Name = "Category")]
        public int CategoryID { get; set; }
        public SelectList? CategoryList { get; set; }

        public List<IFormFile> Images { get; set; }
    }
}

