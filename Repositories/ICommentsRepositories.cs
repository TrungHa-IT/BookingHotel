using HotelBooking.Models;

namespace HotelBooking.Repositories
{
    public interface ICommentsRepositories
    {
        Task<IEnumerable<Comments>> GetAllCommentAsync();
        Task<IEnumerable<Comments>> GetCommentPagedAsync(int pageNumber, int pageSize, string name);
        Task<Comments> GetCommentByIdAsync(int id);
        Task CreateCommentAsync(Comments comment);
        Task UpdateCommentAsync(Comments comment);
        Task DeleteCommentAsync(int id);
        Task<bool> CommentExistAsync(int id);
    }
}
