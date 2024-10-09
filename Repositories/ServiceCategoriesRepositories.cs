using HotelBooking.Models;
using System.Data;

namespace HotelBooking.Repositories
{
    public class ServiceCategoriesRepositories : IServiceCategoriesRepositories
    {
        private readonly UnitOfWork _unitOfWork;
        public ServiceCategoriesRepositories(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task CreateServiceCategoriesAsync(ServiceCategories serviceCategories)
        {
            _unitOfWork._serviceCategoriesRepository.Add(serviceCategories);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteServiceCategoriesAsync(int id)
        {
            var sc = await _unitOfWork._serviceCategoriesRepository.GetByIdAsync(id);
            if (sc != null)
            {
                _unitOfWork._serviceCategoriesRepository.Remove(sc);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ServiceCategories>> GetAllServiceCategoriesAsync()
        {
            return await _unitOfWork._serviceCategoriesRepository.GetAllAsync();
        }

        public async Task<ServiceCategories> GetServiceCategoriesByIdAsync(int id)
        {
            return await _unitOfWork._serviceCategoriesRepository.GetByIdAsync(id);
        }

        public async Task<bool> ServiceCategoriesExistAsync(int id)
        {
            return await _unitOfWork._serviceCategoriesRepository.ExistsAsync(id);
        }

        public async Task UpdateServiceCategoriesAsync(ServiceCategories serviceCategories)
        {
            _unitOfWork._serviceCategoriesRepository.Update(serviceCategories);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
