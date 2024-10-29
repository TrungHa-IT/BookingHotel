using Google.Cloud.Storage.V1;
using HotelBooking.Models;

namespace HotelBooking.Repositories
{
    public class UsingImageRepositories : IUsingImageRepositories
    {
      
        public Task CreateUsingImageAsync(UsingImage usingImage, List<FormFile> images)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UsingImage>> GetAllUsingImageAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UsingImage> GetUsingImageByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
