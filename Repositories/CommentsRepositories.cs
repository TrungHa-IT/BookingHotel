using HotelBooking.Models;

namespace HotelBooking.Repositories
{
    public class CommentsRepositories : ICommentsRepositories
    {
        private readonly UnitOfWork _unitOfWork;

        public CommentsRepositories(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CommentExistAsync(int id)
        {
            return await _unitOfWork._commentRepository.ExistsAsync(id);
        }

        public async Task CreateCommentAsync(Comments comment)
        {
             _unitOfWork._commentRepository.AddAsync(comment);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(int id)
        {
            var comments = await _unitOfWork._commentRepository.GetByIdAsync(id);
            if (comments != null)
            {
                _unitOfWork._commentRepository.Remove(comments);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Comments>> GetAllCommentAsync()
        {
           return await _unitOfWork._commentRepository.GetAllAsync();
        }

        public async Task<Comments> GetCommentByIdAsync(int id)
        {
            return await _unitOfWork._commentRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Comments>> GetCommentPagedAsync(int pageNumber, int pageSize, string name)
        {
            // Tính toán số lượng mục cần bỏ qua dựa trên pageNumber và pageSize
            int skipCount = (pageNumber - 1) * pageSize;

            // Thao tác truy vấn áp dụng phân trang và sắp xếp theo Id
            Func<IQueryable<Comments>, IQueryable<Comments>> queryOperation = query =>
                query.Skip(skipCount).Take(pageSize).OrderBy(c => c.CommentID);

            // Gọi GetManyAsync mà không cần bộ lọc predicate
            return await _unitOfWork._commentRepository.GetManyAsync(
                predicate: null, // Không áp dụng bộ lọc, lấy tất cả
                queryOperation: queryOperation
            );
        }


        public async Task UpdateCommentAsync(Comments comment)
        {
            _unitOfWork._commentRepository.Update(comment);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
