using HotelBooking.Models;

namespace HotelBooking.Repositories
{
    public interface ICategoriesRoomRepository
    {
        Task<IEnumerable<CategoriesRoom>> GetAllCategoriesRoomAsync();
        Task<CategoriesRoom> GetCategoriesRoomByIdAsync(int id);
        Task CreateCategoriesRoomAsync(CategoriesRoom categoriesRoom);
        Task UpdateCategoriesRoomAsync(CategoriesRoom categoriesRoom);
        Task DeleteCategoriesRoomAsync(int id);
        Task<bool> CategoriesRoomExistAsync(int id);
    }
}
