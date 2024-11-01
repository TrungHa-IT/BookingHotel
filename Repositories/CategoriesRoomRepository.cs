using HotelBooking.Models;

namespace HotelBooking.Repositories
{
    public class CategoriesRoomRepository : ICategoriesRoomRepository
    {
        private readonly UnitOfWork _unitOfWork;

        public CategoriesRoomRepository(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CategoriesRoomExistAsync(int id)
        {
            return await _unitOfWork._categoriesRoomRepository.ExistsAsync(id);
        }

        public async Task CreateCategoriesRoomAsync(CategoriesRoom categoriesRoom)
        {
            _unitOfWork._categoriesRoomRepository.Add(categoriesRoom);
             await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteCategoriesRoomAsync(int id)
        {
            var categoriesRooms = await _unitOfWork._categoriesRoomRepository.GetByIdAsync(id);
            if (categoriesRooms != null)
            {
                _unitOfWork._categoriesRoomRepository.Remove(categoriesRooms);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CategoriesRoom>> GetAllCategoriesRoomAsync()
        {
            return await _unitOfWork._categoriesRoomRepository.GetAllAsync();
        }

        public async Task<CategoriesRoom?> GetCategoriesRoomByIdAsync(int id)
        {
            return await _unitOfWork._categoriesRoomRepository.GetByIdAsync(id);
        }

        public async Task UpdateCategoriesRoomAsync(CategoriesRoom categoriesRoom)
        {
            _unitOfWork._categoriesRoomRepository.Update(categoriesRoom);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
