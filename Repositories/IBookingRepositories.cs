using HotelBooking.Models;

namespace HotelBooking.Repositories
{
 public interface IBookingRepositories
    {
        Task<IEnumerable<Booking>> GetAllBookingsAsync();

        Task<Booking> GetBookingsByIdAsync(int id);

        Task CreateBookingAsync(Booking booking);

        Task DeleteBookingAsync(int id);

        Task UpdateBookingAsync(Booking booking);
    }
}