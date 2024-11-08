using HotelBooking.Models;

namespace HotelBooking.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<ServiceCategories> ServiceCategories { get; set; }
        public IEnumerable<Room> Room { get; set; } 
        public IEnumerable<CategoriesRoom> CategoriesRoom { get; set; } 
        public IEnumerable<Service> services { get; set; }
        public IEnumerable<Blog> Blog { get; set; }
    }
}
