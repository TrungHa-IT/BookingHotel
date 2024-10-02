using HotelBooking.Models;
using System.Data;

namespace HotelBooking.Repositories
{
    public class LikeRecordRepositories : ILikeRecordRepositories
    {
        private readonly UnitOfWork _unitOfWork;

        public LikeRecordRepositories(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateLikeRecordAsync(LikeRecord LikeRecord)
        {
            _unitOfWork._likerecordRepository.Add(LikeRecord);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteLikeRecordAsync(LikeRecord likeRecord)
        {
            _unitOfWork._likerecordRepository.Remove(likeRecord);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<LikeRecord>> GetAllLikeRecordAsync()
        {
            return await _unitOfWork._likerecordRepository.GetAllAsync();  
        }

        public async Task<LikeRecord> GetLikeRecordByIdAsync(int commentId, string userId)
        {
            return await _unitOfWork._likerecordRepository.GetLikeByIdAsync(commentId, userId);
        }

        public async Task<bool> UserHasLikedCommentAsync(int commentId, string userId)
        {
            return await _unitOfWork._likerecordRepository.UserHasLikedCommentAsync(commentId, userId);
        }
    }
}
