using HotelBooking.Models;

namespace HotelBooking.Repositories
{
    public interface IBookingServiceRepositories
    {
        Task<IEnumerable<BookingService>> GetAllBookingServiceAsync();
        Task<BookingService> GetBookingServiceByIdAsync(int id);
        Task CreateBookingServiceAsync(BookingService bookingService);
        Task UpdateBookingServiceAsync(BookingService bookingService);
        Task DeleteBookingServiceAsync(int id);
        Task<bool> BookingServiceExistAsync(int id);
    }
}
