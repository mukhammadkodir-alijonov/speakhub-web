using Microsoft.EntityFrameworkCore.ChangeTracking;
using SpeakHub.DataAccess.DbContexts;
using SpeakHub.DataAccess.Interfaces;
using SpeakHub.DataAccess.Interfaces.Common;

namespace SpeakHub.DataAccess.Repositories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public ILikeRepository Likes { get; }
        public ICommentRepository Comments { get; }
        public IAdminRepository Admins { get; }
        public ITweetRepository Tweets { get; }
        public IUserRepository Users { get; }
        public IFollowRepasitory Follows { get; }

        public UnitOfWork(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
            Likes = new LikeRepository(_dbContext);
            Comments = new CommentRepository(_dbContext);
            Admins = new AdminRepository(_dbContext);
            Tweets = new TweetRepository(_dbContext);
            Users = new UserRepository(_dbContext);
            Follows = new FollowRepasitory(_dbContext);
        }
        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
            => _dbContext.Entry(entity);

        public async Task<int> SaveChangesAsync()
            => await _dbContext.SaveChangesAsync();
    }
}