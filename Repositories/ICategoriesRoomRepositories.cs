using HotelBooking.Models;

namespace HotelBooking.Repositories
{
    public interface ICategoriesRoomRepositories
    {
        Task<IEnumerable<CategoriesRoom>> GetAllCategoriesRoomAsync();
        Task CreateCategoriesRoomAsync(CategoriesRoom categoriesRoom);
        Task DeleteCategoriesRoomAsync(int id);
        Task<CategoriesRoom> GetCategoriesRoomByIdAsync(int id);
        Task<bool> CategoriesRoomExistAsync(int id);
        Task UpdateServiceCategoriesAsync(CategoriesRoom categoriesRoom);
    }
}
