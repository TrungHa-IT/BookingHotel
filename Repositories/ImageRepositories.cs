using HotelBooking.Models;
using HotelBooking.Services;

namespace HotelBooking.Repositories
{
    public class ImageRepositories : IImageRepositories
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ICloudinaryService _icloudinaryService;
        public ImageRepositories(UnitOfWork unitOfWork,ICloudinaryService cloudinaryService)
        {
            _icloudinaryService = cloudinaryService;
            _unitOfWork = unitOfWork;
        }
        public async Task CreateImageAsync(List<IFormFile> files, int relationID, string relationName)
        {

            foreach (var file in files)
            {
                var image = new Image
                {
                    RID = relationID,
                    Relation = relationName,
                    imageURL = await _icloudinaryService.UploadImageAsync(file),
                    name = file.FileName,
                };
                _unitOfWork._imageRepository.Add(image);
                await _unitOfWork.SaveChangesAsync();
            }
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
