using HotelBooking.Models;

namespace HotelBooking.Repositories
{
    public class ImageRepositories : IImageRepositories
    {
        private readonly UnitOfWork _unitOfWork;

        public ImageRepositories(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task CreateImageAsync(Image image)
        {
            _unitOfWork._imageRepository.Add(image);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteImageAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Image> GetImageAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Image>> GetAllImagesAsync()
        {
           return await _unitOfWork._imageRepository.GetAllAsync();
        }

        public async Task UpdateImageAsync(Image image)
        {
            throw new NotImplementedException();
        }
    }
}
