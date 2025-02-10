using HotelBooking.Models;

namespace HotelBooking.Repositories
{
    public interface IImageRepositories
    {
        Task<IEnumerable<Image>> GetAllImagesAsync();
        Task<Image> GetImageAsync(int id);
        Task CreateImageAsync(Image image);
        Task UpdateImageAsync(Image image);
        Task DeleteImageAsync(int id);
    }
}
