using HotelBooking.Models;

namespace HotelBooking.Repositories
{
    public interface ICategoriesRepositories
    {
        Task<IEnumerable<Categories>> GetAllCategoriesAsync();
        Task<IEnumerable<Categories>> GetCategoriesPagedAsync(int pageNumber, int pageSize, string name);
        Task<Categories> GetCategoriesByIdAsync(int id);
        Task CreateCategoriesAsync(Categories category);
        Task UpdateCategoriesAsync(Categories category);
        Task DeleteCategoriesAsync(int id);
        Task<bool> CategoriesExistAsync(int id);
    }
}
