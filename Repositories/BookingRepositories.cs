using HotelBooking.Models;

namespace HotelBooking.Repositories
{
    public class BookingRepositories : IBookingRepositories
    {

        private readonly UnitOfWork _unitOfWork;

        public BookingRepositories(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task CreateBookingAsync(Booking booking)
        {
            await _unitOfWork._bookingRepository.AddAsync(booking);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteBookingAsync(int id)
        {
            var booking = await _unitOfWork._bookingRepository.GetByIdAsync(id);
            if (booking != null)
            {
                _unitOfWork._bookingRepository.Remove(booking);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await _unitOfWork._bookingRepository.GetAllAsync();
        }

        public async Task<Booking> GetBookingsAsync(int id)
        {
            return await _unitOfWork._bookingRepository.GetByIdAsync(id);
        }

        public async Task UpdateBookingAsync(Booking booking)
        {

          _unitOfWork._bookingRepository.Update(booking);
          await _unitOfWork.SaveChangesAsync();
        }
    }
}