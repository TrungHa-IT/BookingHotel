using HotelBooking.Data;
using HotelBooking.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace HotelBooking.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private readonly AppDbContext _dbContext;
        private IDbContextTransaction? _transaction;
        public IRepository<Categories> _categoriesRepository { get; set; }
        public IRepository<Roles> _roleRepository { get; set; }
        public IRepository<Blog> _blogRepository { get; set; }
        public IRepository<Comments> _commentRepository { get; set; }

        private bool _disposed = false;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _categoriesRepository = new Repository<Categories>(_dbContext);
            _roleRepository = new Repository<Roles>(_dbContext);
            _blogRepository = new Repository<Blog>(_dbContext);
            _commentRepository = new Repository<Comments>(_dbContext);  
        }
        
        /// <summary>
        /// Starts a new transaction.
        /// </summary>
        public void CreateTransaction()
        {
            _transaction = _dbContext.Database.BeginTransaction();
        }

        /// <summary>
        /// Starts a new transaction asynchronously.
        /// </summary>
        public async Task CreateTransactionAsync()
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync();
        }

        /// <summary>
        /// Commits the current transaction.
        /// </summary>
        public void Commit()
        {
            try
            {
                SaveChanges();
                _transaction?.Commit();
            }
            catch
            {
                Rollback();
                throw;
            }
            finally
            {
                _transaction?.Dispose();
            }
        }

        /// <summary>
        /// Commits the current transaction asynchronously.
        /// </summary>
        public async Task CommitAsync()
        {
            try
            {
                await SaveChangesAsync();
                if (_transaction != null)
                {
                    await _transaction.CommitAsync();
                }
            }
            catch
            {
                await RollbackAsync();
                throw;
            }
            finally
            {
                if (_transaction != null)
                {
                    await _transaction.DisposeAsync();
                }
            }
        }

        /// <summary>
        /// Rolls back the current transaction.
        /// </summary>
        public void Rollback()
        {
            _transaction?.Rollback();
            _transaction?.Dispose();
        }

        /// <summary>
        /// Rolls back the current transaction asynchronously.
        /// </summary>
        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
            }
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                    _transaction?.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
