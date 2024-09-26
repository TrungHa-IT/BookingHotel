using HotelBooking.Models;

namespace HotelBooking.Repositories
{
    public interface IRoleRepositories
    {
        Task<IEnumerable<Roles>> GetAllRoleAsync();
        Task<IEnumerable<Roles>> GetRolePagedAsync(int pageNumber, int pageSize, string name);
        Task<Roles> GetRoleByIdAsync(int id);
        Task CreateRoleAsync(Roles role);
        Task UpdateRoleAsync(Roles role);
        Task DeleteRoleAsync(int id);
        Task<bool> RoleExistAsync(int id);
    }
}
