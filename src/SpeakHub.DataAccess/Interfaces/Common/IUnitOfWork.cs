using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SpeakHub.DataAccess.Interfaces.Common
{
    public interface IUnitOfWork
    {
        public IAdminRepository Admins { get; }
        public ITweetRepository Tweets { get; }
        public ILikeRepository Likes { get; }
        public ICommentRepository Comments { get; }
        public IUserRepository Users { get; }
        public IFollowRepasitory Follows { get; }
        public Task<int> SaveChangesAsync();
        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}