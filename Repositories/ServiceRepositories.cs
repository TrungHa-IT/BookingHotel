using HotelBooking.Models;

namespace HotelBooking.Repositories
{
    public class ServiceRepositories : IServiceRepositories
    {
        private readonly UnitOfWork _unitOfWork;
        public ServiceRepositories(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task CreateServicesAsync(Service service)
        {
            _unitOfWork._serviceRepository.Add(service);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteServiceAsync(int id)
        {
            var service = await _unitOfWork._serviceRepository.GetByIdAsync(id);
            if (service != null)
            {
                _unitOfWork._serviceRepository.Remove(service);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Service>> GetAllServiceAsync()
        {
            return await _unitOfWork._serviceRepository.GetAllAsync();
        }

        public async Task<Service> GetServiceByIdAsync(int id)
        {
            return await _unitOfWork._serviceRepository.GetByIdAsync(id); 
        }

        public async Task<bool> ServiceExistAsync(int id)
        {
            return await _unitOfWork._serviceRepository.ExistsAsync(id);
        }

        public async Task UpdateServiceAsync(Service service)
        {
            _unitOfWork._serviceRepository.Update(service);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
