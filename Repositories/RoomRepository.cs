using HotelBooking.Models;
using HotelBooking.ViewModels;
using Microsoft.AspNetCore.Razor.Language.Extensions;

namespace HotelBooking.Repositories
{
    public class RoomRepository : IRoomRepositories
    {
        private readonly UnitOfWork _unitOfWork;
        public RoomRepository(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task CreateRoomAsync(Room room)
        {
            _unitOfWork._roomRepository.Add(room);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteRoomAsync(int id)
        {
            var sc = await _unitOfWork._roomRepository.GetByIdAsync(id);
            if (sc != null)
            {
                _unitOfWork._roomRepository.Remove(sc);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Room>> GetAllRoomAsync()
        {
            return await _unitOfWork._roomRepository.GetAllAsync();
        }

        public async Task<Room?> GetRoomByIdAsync(int id)
        {
            return await _unitOfWork._roomRepository.GetByIdAsync(id);
        }

        public async Task<bool> RoomExistAsync(int id)
        {
            return await _unitOfWork._roomRepository.ExistsAsync(id);
        }

        public async Task UpdateRoomAsync(Room room)
        {
            _unitOfWork._roomRepository.Update(room);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
