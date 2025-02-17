using HotelBooking.Models;

namespace HotelBooking.Repositories
{
    public interface IBookAbleRepositories
    {

        Task<IEnumerable<BookAble>> GetAllBookAbleAsync();

        Task<BookAble> GetBookAbleByIdAsync(int id);

        Task CreateBookAbleAsync(BookAble bookAble);

        Task UpdateBookAbleAsync(BookAble bookAble);

        Task DeleteBookAbleAsync(int id);


    }
}