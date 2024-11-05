using HotelBooking.Models;

namespace HotelBooking.Repositories
{
    public interface IVoucherRepositories
    {
        Task<IEnumerable<Voucher>> GetAllVoucherAsync();
        Task<Voucher> GetVoucherByIdAsync(int id);
        Task CreateVoucherAsync(Voucher voucher);
        Task UpdateVoucherAsync(Voucher voucher);
        Task DeleteVoucherAsync(int id);
        Task<bool> VoucherExistAsync(int id);
    }
}
