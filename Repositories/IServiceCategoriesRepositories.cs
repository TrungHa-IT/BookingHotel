using HotelBooking.Models;

namespace HotelBooking.Repositories
{
    public interface IServiceCategoriesRepositories
    {
        Task<IEnumerable<ServiceCategories>> GetAllServiceCategoriesAsync();
        Task<ServiceCategories> GetServiceCategoriesByIdAsync(int id);
        Task CreateServiceCategoriesAsync(ServiceCategories serviceCategories);
        Task UpdateServiceCategoriesAsync(ServiceCategories serviceCategories);
        Task DeleteServiceCategoriesAsync(int id);
        Task<bool> ServiceCategoriesExistAsync(int id);
    }
}
