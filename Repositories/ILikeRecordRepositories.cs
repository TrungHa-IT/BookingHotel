using HotelBooking.Models;

namespace HotelBooking.Repositories
{
    public interface ILikeRecordRepositories
    {
        Task<IEnumerable<LikeRecord>> GetAllLikeRecordAsync();
        Task<bool> UserHasLikedCommentAsync(int commentId, string userId);
        Task<LikeRecord> GetLikeRecordByIdAsync(int commentId, string userId);
        Task CreateLikeRecordAsync(LikeRecord LikeRecord);
        Task DeleteLikeRecordAsync(LikeRecord likeRecord);
    }
}
