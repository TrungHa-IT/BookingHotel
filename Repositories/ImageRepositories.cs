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
           var image = await _unitOfWork._imageRepository.GetByIdAsync(id);
            if (image != null)
            {
                _unitOfWork._imageRepository.Remove(image);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<Image> GetImageAsync(int id)
        {

           return await _unitOfWork._imageRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Image>> GetAllImagesAsync()
        {
           return await _unitOfWork._imageRepository.GetAllAsync();
        }
    }
}
