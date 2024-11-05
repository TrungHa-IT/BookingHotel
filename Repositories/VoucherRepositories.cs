using HotelBooking.Models;

namespace HotelBooking.Repositories
{
    public class VoucherRepositories : IVoucherRepositories
    {
        private readonly UnitOfWork _unitOfWork;
        public VoucherRepositories(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task CreateVoucherAsync(Voucher voucher)
        {
            _unitOfWork._voucherRepository.Add(voucher);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteVoucherAsync(int id)
        {
            var service = await _unitOfWork._voucherRepository.GetByIdAsync(id);
            if (service != null)
            {
                _unitOfWork._voucherRepository.Remove(service);
                await _unitOfWork.SaveChangesAsync();
            }        
        }

        public async Task<IEnumerable<Voucher>> GetAllVoucherAsync()
        {
            return await _unitOfWork._voucherRepository.GetAllAsync();
        }

        public async Task<Voucher> GetVoucherByIdAsync(int id)
        {
            return await _unitOfWork._voucherRepository.GetByIdAsync(id);
        }

        public async Task UpdateVoucherAsync(Voucher voucher)
        {
            _unitOfWork._voucherRepository.Update(voucher);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> VoucherExistAsync(int id)
        {
            return await _unitOfWork._voucherRepository.ExistsAsync(id);
        }
    }
}
