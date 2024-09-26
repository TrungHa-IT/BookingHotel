using HotelBooking.Data;
using HotelBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Repositories
{
    public class CategoriesRepository : ICategoriesRepositories
    {
        private readonly UnitOfWork _unitOfWork;

        public CategoriesRepository(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CategoriesExistAsync(int id)
        {
            return await _unitOfWork._categoriesRepository.ExistsAsync(id);
        }

        public async Task CreateCategoriesAsync(Categories category)
        {
            _unitOfWork._categoriesRepository.Add(category);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteCategoriesAsync(int id)
        {
            var categories = await _unitOfWork._categoriesRepository.GetByIdAsync(id);
            if(categories != null) 
            {
                _unitOfWork._categoriesRepository.Remove(categories);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Categories>> GetAllCategoriesAsync()
        {
            return await _unitOfWork._categoriesRepository.GetAllAsync();

        }

        public async Task<Categories> GetCategoriesByIdAsync(int id)
        {
            return await _unitOfWork._categoriesRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Categories>> GetCategoriesPagedAsync(int pageNumber, int pageSize, string name)
        {
            // Calculate skipping items based on pageNumber and pageSize
            int skipCount = (pageNumber - 1) * pageSize;

            // Query operation to apply pagination and filter by name
            Func<IQueryable<Categories>, IQueryable<Categories>> queryOperation = query =>
                query.Skip(skipCount).Take(pageSize).OrderBy(c => c.Id);

            // Call GetManyAsync with the predicate and query operation
            return await _unitOfWork._categoriesRepository.GetManyAsync(
                predicate: c => c.Name!.Contains(name), // Filter by name
                queryOperation: queryOperation
            );
        }

        public async Task UpdateCategoriesAsync(Categories category)
        {
            _unitOfWork._categoriesRepository.Update(category);
            await _unitOfWork.SaveChangesAsync();
        }

    
    }
}
