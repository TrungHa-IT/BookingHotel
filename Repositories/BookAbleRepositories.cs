using HotelBooking.Models;

namespace HotelBooking.Repositories
{
    public class BookAbleRepositories : IBookAbleRepositories
    {

        private readonly UnitOfWork _unitOfWork;

        public BookAbleRepositories(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task CreateBookAbleAsync(BookAble bookAble)
        {
            _unitOfWork._bookAbleRepository.Add(bookAble);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteBookAbleAsync(int id)
        {
            var bookAble = _unitOfWork._bookAbleRepository.GetById(id);
            if (bookAble != null)
            {
                _unitOfWork._bookAbleRepository.Remove(bookAble);
                await _unitOfWork.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<BookAble>> GetAllBookAbleAsync()
        {
            return await _unitOfWork._bookAbleRepository.GetAllAsync();
        }

        public async Task<BookAble> GetBookAbleByIdAsync(int id)
        {
            return await _unitOfWork._bookAbleRepository.GetByIdAsync(id);
        }

        public async Task UpdateBookAbleAsync(BookAble bookAble)
        {
            _unitOfWork._bookAbleRepository.Update(bookAble);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}