using HotelBooking.Models;

namespace HotelBooking.Repositories
{
    public interface IBlogRepositories
    {
        Task<IEnumerable<Blog>> GetAllBlogAsync();
        Task<IEnumerable<Blog>> GetBlogPagedAsync(int pageNumber, int pageSize, string name);
        Task<Blog> GetBlogByIdAsync(int id);
        Task CreateBlogAsync(Blog blog);
        Task UpdateBlogAsync(Blog blog);
        Task DeleteBlogAsync(int id);
        Task<bool> BlogExistAsync(int id);
    }
}
