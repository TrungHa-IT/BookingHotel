
using System.IO;
using System.Security.Policy;
using System.Threading.Tasks;
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

        public async Task CreateImagesAsync(int relationId,int typeId, List<IFormFile> imageUrls)
        { int count = 0;
           if(imageUrls != null && imageUrls.Count > 0)
            {
                foreach (var imageUrl in imageUrls)
                { count++;
                   
                   string url = _unitOfWork._imageRepository.ConvertIFormFileToString(imageUrl);
                    var newImage = new Image
                    {
                        imageURL = url,
                        name = count.ToString(),
                        create_at = DateTime.Now,

                    };

                    _unitOfWork._imageRepository.Add(newImage);
                   
                    //int lastId = _unitOfWork._imageRepository.GetMaxId();
                    //var usingIamge = new UsingImage
                    //{
                    //    TypeID = typeId,
                    //    ImageID = lastId,
                    //    RID = relationId,
                    //};

                    //_unitOfWork._usingImageRepository.Add(usingIamge);
                }
            }
         
          await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteImageAsync(int id)
        {
           var sc = await _unitOfWork._imageRepository.GetByIdAsync(id);
            if (sc != null)
            {
                _unitOfWork._imageRepository.Remove(sc);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Image>> GetAllImageAsync()
        {
            return await _unitOfWork._imageRepository.GetAllAsync();
        }

        public async Task<Image> GetImageByIdAsync(int id)
        {
            return await _unitOfWork._imageRepository.GetByIdAsync(id);
        }

        public Task<bool> ImageExistAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateImageAsync(Image image)
        {
            throw new NotImplementedException();
        }
       
    }
}
