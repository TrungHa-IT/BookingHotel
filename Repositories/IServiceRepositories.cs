using HotelBooking.Models;

namespace HotelBooking.Repositories
{
    public interface IServiceRepositories
    {
        Task<IEnumerable<Service>> GetAllServiceAsync();
        Task<Service> GetServiceByIdAsync(int id);
        Task<IEnumerable<Service>> GetServiceByIdServiceCategoryAsync(int id);
        Task CreateServicesAsync(Service service);
        Task UpdateServiceAsync(Service service);
        Task DeleteServiceAsync(int id);
        Task<bool> ServiceExistAsync(int id);
    }
}
