using HotelBooking.Models;

namespace HotelBooking.Repositories
{
    public interface IImageRepositories
    {
        Task<IEnumerable<Image>> GetAllImageAsync();
        Task<Image> GetImageByIdAsync(int id);
        Task CreateImageAsync(Image image);
        Task UpdateImageAsync(Image image);
        Task DeleteImageAsync(int id);
        Task<bool> ImageExistAsync(int id);
    }
}
