using HotelBooking.Models;

namespace HotelBooking.Repositories
{
    public class RoleRepositories : IRoleRepositories
    {
        private readonly UnitOfWork _unitOfWork;
        public RoleRepositories(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task CreateRoleAsync(Roles role)
        {
            _unitOfWork._roleRepository.Add(role);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(int id)
        {
            var role = await _unitOfWork._roleRepository.GetByIdAsync(id);
            if (role != null)
            {
                _unitOfWork._roleRepository.Remove(role);   
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Roles>> GetAllRoleAsync()
        {
            return await _unitOfWork._roleRepository.GetAllAsync();
        }

        public async Task<Roles> GetRoleByIdAsync(int id)
        {
            return await _unitOfWork._roleRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Roles>> GetRolePagedAsync(int pageNumber, int pageSize, string name)
        {
            // Calculate skipping items based on pageNumber and pageSize
            int skipCount = (pageNumber - 1) * pageSize;

            // Query operation to apply pagination and filter by name
            Func<IQueryable<Roles>, IQueryable<Roles>> queryOperation = query =>
                query.Skip(skipCount).Take(pageSize).OrderBy(c => c.Id);

            // Call GetManyAsync with the predicate and query operation
            return await _unitOfWork._roleRepository.GetManyAsync(
                predicate: c => c.RoleUser!.Contains(name), // Filter by name
                queryOperation: queryOperation
            );
        }

        public async Task<bool> RoleExistAsync(int id)
        {
            return await _unitOfWork._roleRepository.ExistsAsync(id);   
        }

        public async Task UpdateRoleAsync(Roles role)
        {
            _unitOfWork._roleRepository.Update(role);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
