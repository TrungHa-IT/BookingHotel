using HotelBooking.Models;

namespace HotelBooking.Repositories
{
    public interface IImageRepositories
    {
        Task<IEnumerable<Image>> GetAllImagesAsync();
        Task<Image> GetImageAsync(int id);
        Task CreateImageAsync(List<IFormFile> files, int relationID, string relationName);
        Task DeleteImageAsync(int id);
    }
}
