using HotelBooking.Models;

namespace HotelBooking.Repositories
{
    public interface IUsingImageRepositories
    {
        Task<IEnumerable<UsingImage>> GetAllUsingImageAsync();
        Task<UsingImage> GetUsingImageByIdAsync(int id);
        Task CreateUsingImageAsync(UsingImage usingImage);
        Task UpdateUsingImageAsync(UsingImage usingImage);
        Task DeleteUsingImageAsync(int id);
        Task<bool> UsingImageExistAsync(int id);
    }
}
