using HotelBooking.Models;
using HotelBooking.Services;

namespace HotelBooking.Repositories
{
    public class ImageRepositories : IImageRepositories
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ICloudinaryService _icloudinaryService;
        public ImageRepositories(UnitOfWork unitOfWork, ICloudinaryService cloudinaryService)
        {
            _icloudinaryService = cloudinaryService;
            _unitOfWork = unitOfWork;
        }
        public async Task CreateImageAsync(List<IFormFile> files, int relationID, string relationName)
        {

            List<Image> newImages = new List<Image>();
            int count = 1;
            foreach (var file in files)
            {
                var image = new Image
                {
                    RID = relationID,
                    Relation = relationName,
                    imageURL = await _icloudinaryService.UploadImageAsync(file),
                    name = relationName + "~" + relationID + "~" + count + ".jpg",
                };
                newImages.Add(image);
                count++;
            }
            _unitOfWork._imageRepository.AddRange(newImages);
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

        public async Task<List<Image?>> GetAllImageByIdOfRelationID(int relationID, string relationName)
        {
            return await _unitOfWork._imageRepository.GetImageByRIDAsync(relationID, relationName);
        }

        public async Task UpdateAllImage(List<IFormFile> files, string relationName, int relationID)
        {
            List<Image?> images = await _unitOfWork._imageRepository.GetImageByRIDAsync(relationID, relationName);

            if (images != null && images.Count > 0)
            {
                _unitOfWork._imageRepository.RemoveRange(images);
                await _unitOfWork.SaveChangesAsync();
            }

            List<Image> newImages = new List<Image>();
            int count = 1;
            foreach (var file in files)
            {
                var image = new Image
                {
                    RID = relationID,
                    Relation = relationName,
                    imageURL = await _icloudinaryService.UploadImageAsync(file),
                    name = relationName + "~" + relationID + "~" + count + ".jpg",
                };
                newImages.Add(image);
                count++;
            }

            _unitOfWork._imageRepository.AddRange(newImages);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
