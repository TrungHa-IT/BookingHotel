using HotelBooking.Models;
using System.Data;

namespace HotelBooking.Repositories
{
    public class CategoriesRoomRepositories : ICategoriesRoomRepositories
    {
        private readonly UnitOfWork _unitOfWork;
    
        public CategoriesRoomRepositories(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateCategoriesRoomAsync(CategoriesRoom categoriesRoom)
        {
            _unitOfWork._categoriesRoomRepository.Add(categoriesRoom);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteCategoriesRoomAsync(int id)
        {
            var sc = await _unitOfWork._categoriesRoomRepository.GetByIdAsync(id);
            if (sc != null)
            {
                _unitOfWork._categoriesRoomRepository.Remove(sc);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CategoriesRoom>> GetAllCategoriesRoomAsync()
        {
            return await _unitOfWork._categoriesRoomRepository.GetAllAsync();
        }

        public async Task<CategoriesRoom> GetCategoriesRoomByIdAsync(int id)
        {
            return await _unitOfWork._categoriesRoomRepository.GetByIdAsync(id);
        }

        public async Task<bool> CategoriesRoomExistAsync(int id)
        {
            return await _unitOfWork._categoriesRoomRepository.ExistsAsync(id);
        }

        public async Task UpdateServiceCategoriesAsync(CategoriesRoom categoriesRoom)
        {
            _unitOfWork._categoriesRoomRepository.Update(categoriesRoom);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
