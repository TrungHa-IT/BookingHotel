using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace HotelBooking.Services
{
    public interface ICloudinaryService
    {
         Task<string> UploadImageAsync(IFormFile file);
    }
}
