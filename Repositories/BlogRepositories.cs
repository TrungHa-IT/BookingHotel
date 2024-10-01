using HotelBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Repositories
{
    public class BlogRepositories : IBlogRepositories
    {

        private readonly UnitOfWork _unitOfWork;

        public BlogRepositories (UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<bool> BlogExistAsync(int id)
        {
            return _unitOfWork._blogRepository.ExistsAsync(id);
        }

        public async Task CreateBlogAsync(Blog blog)
        {
            _unitOfWork._blogRepository.Add(blog);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteBlogAsync(int id)
        {
            var blogs = await _unitOfWork._blogRepository.GetByIdAsync(id);
            if (blogs != null)
            {
                _unitOfWork._blogRepository.Remove(blogs);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Blog>> GetAllBlogAsync()
        {
             return await _unitOfWork._blogRepository.GetAllAsync();
        }

        public async Task<Blog> GetBlogByIdAsync(int id)
        {
            return await _unitOfWork._blogRepository.GetByIdAsync(id);
        }




        public async Task<IEnumerable<Blog>> GetBlogPagedAsync(int pageNumber, int pageSize, string name)
        {
            // Tính toán số lượng mục cần bỏ qua dựa trên pageNumber và pageSize
            int skipCount = (pageNumber - 1) * pageSize;

            // Thao tác truy vấn áp dụng phân trang và sắp xếp theo Id
            Func<IQueryable<Blog>, IQueryable<Blog>> queryOperation = query =>
                query.Skip(skipCount).Take(pageSize).OrderBy(c => c.Id);

            // Gọi GetManyAsync mà không cần bộ lọc predicate
            return await _unitOfWork._blogRepository.GetManyAsync(
                predicate: null, // Không áp dụng bộ lọc, lấy tất cả
                queryOperation: queryOperation
            );
        }

        public async Task UpdateBlogAsync(Blog blog)
        {
            _unitOfWork._blogRepository.Update(blog);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
