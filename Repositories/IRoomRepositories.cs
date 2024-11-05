using HotelBooking.Models;

namespace HotelBooking.Repositories
{
    public interface IRoomRepositories
    {
        Task<IEnumerable<Room>> GetAllRoomAsync();
        Task<Room> GetRoomByIdAsync(int id);
        Task CreateRoomAsync(Room room);
        Task UpdateRoomAsync(Room room);
        Task DeleteRoomAsync(int id);
        Task<bool> RoomExistAsync(int id);
    }
}
